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
        private string playlistname;
        private List<Music> songlist = new List<Music>();

        public Playlist(string playlistname)
        {
            this.playlistname = playlistname;
        }
        public void addsong(Music music)
        {
            songlist.Add(music);
        }
        public void removeSong(Music music)
        {
            songlist.Remove(music);
        }
        public void getSongName()
        {

        }
        public void musicRandomOrder()
        {

        }

    }
}
