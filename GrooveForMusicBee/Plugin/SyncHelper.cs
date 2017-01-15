using Microsoft.Groove.Api.Client;
using Microsoft.Groove.Api.DataContract;
using Microsoft.Groove.Api.DataContract.CollectionEdit;
using Mono.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicBeePlugin.Plugin;

namespace GrooveForMusicBee
{
    public class SyncHelper
    {
        private IGrooveClient _client;
        private SyncProgressWindow _window;
        private MusicBeeApiInterface _mbApiInterface;

        public SyncHelper(IGrooveClient client, MusicBeeApiInterface mbApiInterface, SyncProgressWindow window)
        {
            _client = client;
            _window = window;
            _mbApiInterface = mbApiInterface;
        }

        public async void GrooveToLocal()
        {

        }

        public async Task<List<PlaylistActionResponse>> LocalToGroove(List<MusicBeePlaylist> playlistsToSync, List<Playlist> existingGroovePlaylists)
        {
            _window.WriteOutputLine("Beginning preparation of playlists");
            _window.WriteOutputLine("Note: matching all the music bee tracks to Groove may take a few minutes");
            List<PlaylistAction> playlistActions = await GetPlaylistActions(playlistsToSync, existingGroovePlaylists);
            if (playlistActions == null)
            {
                return null;
            }

            _window.WriteOutputLine("Prepared selected playlists for syncing. Sending requests...");

            return await PerformPlaylistActions(playlistActions);
        }

        private async Task<List<PlaylistAction>> GetPlaylistActions(List<MusicBeePlaylist> playlistsToSync, List<Playlist> existingGroovePlaylists)
        {
            List<PlaylistAction> playlistActions = new List<PlaylistAction>();
            int totalPlaylistsProcessed = 0;
            foreach (MusicBeePlaylist playlist in playlistsToSync)
            {
                _window.WriteOutputLine($"Preparing {playlist.Name} for sync");

                // If playlist already exists,
                // for now, delete playlist and remake completely
                // eventually, calculate diff
                Playlist matchingGroovePlaylist = existingGroovePlaylists.Where(p => p.Name == playlist.Name).FirstOrDefault();
                if (matchingGroovePlaylist != null)
                {
                    PlaylistAction deletePlaylist = new PlaylistAction()
                    {
                        Id = matchingGroovePlaylist.Id,
                    };
                    playlistActions.Add(deletePlaylist);
                }

                // Get list of file paths to tracks in music bee library
                string[] playlistFiles = null;
                if (_mbApiInterface.Playlist_QueryFiles(playlist.MusicBeeName))
                {
                    bool success = _mbApiInterface.Playlist_QueryFilesEx(playlist.MusicBeeName, ref playlistFiles);
                    if (!success)
                    {
                        _window.WriteOutputLine($"Couldn't find playlist file for: {playlist.Name}");
                        return null;
                    }
                }
                else
                {
                    playlistFiles = new string[] { };
                }

                // Map the track in music bee to Groove
                List<TrackAction> tracksToAdd = new List<TrackAction>();
                foreach (string file in playlistFiles)
                {
                    string title = _mbApiInterface.Library_GetFileTag(file, MetaDataType.TrackTitle);
                    string artist = _mbApiInterface.Library_GetFileTag(file, MetaDataType.Artist);

                    ContentResponse response = await _client.SearchAsync(MediaNamespace.music, HttpUtility.UrlEncode(title), ContentSource.Collection, SearchFilter.Tracks);
                    if (response.Error == null || response.Error.ErrorCode == Enum.GetName(typeof(ErrorCode), ErrorCode.COLLECTION_INVALID_DATA))
                    {
                        TrackAction action = null;
                        List<Track> tracksFound = response.Tracks.Items.Cast<Track>().ToList();
                        foreach (Track track in tracksFound)
                        {
                            if (track.Name == title
                                && track.Artists.Where(c => c.Artist.Name == artist).FirstOrDefault() != null)
                            {
                                action = new TrackAction()
                                {
                                    Action = TrackActionType.Add,
                                    Id = track.Id
                                };
                                tracksToAdd.Add(action);
                            }
                        }

                        if (action == null)
                        {
                            _window.WriteOutputLine($"Could not match track {artist} - {title}");
                        }
                    }
                    else
                    {
                        _window.WriteOutputLine($"Could not match track {artist} - {title}");
                    }
                }

                PlaylistAction createPlaylist = new PlaylistAction()
                {
                    Name = playlist.Name,
                    TrackActions = tracksToAdd
                };
                playlistActions.Add(createPlaylist);

                totalPlaylistsProcessed++;
                _window.UpdatePreparationProgress(100 * totalPlaylistsProcessed / playlistsToSync.Count);
            }

            return playlistActions;
        }

        private async Task<List<PlaylistActionResponse>> PerformPlaylistActions(List<PlaylistAction> playlistActions)
        {
            int totalTrackActions = 0;
            playlistActions.ForEach(a =>
            {
                if (a.TrackActions != null)
                {
                    totalTrackActions += a.TrackActions.Count;
                }
                else
                {
                    totalTrackActions++;
                }
            });

            List<PlaylistActionResponse> responses = new List<PlaylistActionResponse>();
            int totalTrackActionsSoFar = 0;
            for (int i = 0; i < playlistActions.Count; i++)
            {
                PlaylistAction action = playlistActions[i];
                PlaylistActionType operation = action.Name == null ? PlaylistActionType.Delete : PlaylistActionType.Create;
                PlaylistActionResponse response = await _client.PlaylistOperationAsync(MediaNamespace.music, operation, playlistActions[i]);
                responses.Add(response);
                if (response.Error == null)
                {
                    if (action.TrackActions != null)
                    {
                        totalTrackActionsSoFar += action.TrackActions.Count;
                    }

                    _window.UpdateSyncProgress(100 * totalTrackActionsSoFar / totalTrackActions);
                }
                else
                {
                    _window.WriteOutputLine($"Error when syncing: {response.Error.Description}");
                }
            }

            return responses;
        }
    }
}
