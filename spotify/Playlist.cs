using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using music;
namespace playlist
{
    public class Playlist
    {
        protected string playlistname;
        private List<Music> songlist = new List<Music>();

        public Playlist(string playlistname)
        {
            this.playlistname = playlistname;
        }

        public string Playlistname { get { return playlistname; } }
        public void addsong(Music music)
        {
            songlist.Add(music);
        }
        public void removeSong(Music music)
        {
            songlist.Remove(music);
        }
        public Music getSongName(string input)
        {

            foreach (var item in this.songlist)
            {
                if (item.Name == input)
                {
                    return item;
                }

            }
            return null;
        }
        public void musicRandomOrder()
        {

        }
        public void readList()
        {
            foreach (var item in this.songlist)
            {
                Console.WriteLine(item.Name);
            }
        }

    }
}
