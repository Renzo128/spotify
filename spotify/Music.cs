using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music
{
    public class Music
    {
        private string name;
        private int length;
        private string artist;
        private string genre;

        public string Name { get { return name; } set { this.name = value; } }
        public Music(string name, int length, string artist , string genre)
        {
            this.name = name;
            this.length = length;   
            this.artist = artist;
            this.genre = genre;
        }

        public void playsong()
        {

        }
        public void pause()
        {

        }
        public void play()
        {

        }
    }
}
