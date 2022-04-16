using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using music;
using album;
namespace playlist
{
    public class Playlist
    {
        protected string playlistname;
        private List<Music> songlist = new List<Music>();
        private List<Album> albums = new List<Album>();


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

        public Album getAlbumName(string input)
        {

            foreach (var item in this.albums)
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

        public void addAlbum(Album album)
        {
            albums.Add(album);
        }

        public void addAlbumToPlaylist(Album album)
        {
            foreach(var item in album.Songs)
            songlist.Add(item);
        }

    }
}
