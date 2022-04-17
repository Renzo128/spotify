using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using music;
namespace album
{
    public class Album
    {
        private string name;
        public string Name { get { return name; } set { this.name = value; } }
        private List<Music> listOfSongs = new List<Music>();
        public List<Music> Songs { get { return listOfSongs; } set { listOfSongs = value; } }
        private int length;
        private string singer;
        private int amountOfSongs;

        public Album(string name , int length, string singer, int amountOfSongs)
        {
            this.Name = name;
            this.length = length;
            this.singer = singer;
            this.amountOfSongs = amountOfSongs;
        }
        public void addSong(Music music)
        {
            listOfSongs.Add(music);
        }
        public void playAlbum()
        {

        }
    }
}
