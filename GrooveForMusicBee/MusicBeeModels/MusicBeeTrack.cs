using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveForMusicBee
{
    public class MusicBeeTrack
    {
        public string FileName;
        public string Artist;
        public string Title;
        public override string ToString()
        {
            return $"{Artist} - {Title}";
        }
    }
}
