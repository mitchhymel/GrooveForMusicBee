using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveForMusicBee
{
    public class MusicBeePlaylist
    {
        public string MusicBeeName;
        public string Name;

        public MusicBeePlaylist(string name, string mbName)
        {
            Name = name;
            MusicBeeName = mbName;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
