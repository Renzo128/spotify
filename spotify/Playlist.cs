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



        public Playlist(string playlistname)
        {
            this.playlistname = playlistname;
        }

        public string Playlistname { get { return playlistname; } }
        public List<Music> Songlist { get { return songlist; } }
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

        public void musicRandomOrder(int i , int j)
        {

            Random rnd = new Random();

            Music selected_Song = this.getSong(i);
            Console.WriteLine(selected_Song.Name);

            int amountOfSongs = this.Songlist.Count;
            int songLength = selected_Song.Length;
            amountOfSongs--;
            do
            {
                while (!Console.KeyAvailable)
                {
                    System.Threading.Thread.Sleep(1000);
                    j++;
                    if (j >= songLength)
                    {

                        int totalNumbers = amountOfSongs + 1;
                        i = rnd.Next(totalNumbers);

                        if (i > amountOfSongs)
                        {
                            i = 0;
                        }
                        Console.WriteLine(i);
                        selected_Song = this.getSong(i);
                        songLength = selected_Song.Length;

                        Console.WriteLine(selected_Song.Name);
                        j = 0;

                    }
                }

                Console.WriteLine("Klik op escape om terug te gaan");
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("Klik op spatie om het nummer door te spelen");
                }



            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public void musicNormalOrder(int i, int j)
        {

            Music selected_Song = this.getSong(i);
            Console.WriteLine(selected_Song.Name);
            int amountOfSongs = this.Songlist.Count;
            int songLength = selected_Song.Length;
            amountOfSongs--;
            do
            {
                while (!Console.KeyAvailable)
                {
                    System.Threading.Thread.Sleep(1000);
                    j++;
                    if (j >= songLength)
                    {
                            i++;
                        if (i > amountOfSongs)
                        {
                            i = 0;
                        }
                        Console.WriteLine(i);
                        selected_Song = this.getSong(i);
                        songLength = selected_Song.Length;
                        Console.WriteLine(selected_Song.Name);
                        j = 0;

                    }
                }

                Console.WriteLine("Klik op escape om terug te gaan");
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("Klik op spatie om het nummer door te spelen");
                }



            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public Music getSong(int i)
        {
            Console.WriteLine(this.Songlist[i].Name);
            return this.songlist[i];

        }
        public void readList()
        {
            foreach (var item in this.songlist)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void addAlbumToPlaylist(Album album)
        {
            foreach (var item in album.Songs)
                songlist.Add(item);
        }

    }
}
