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
        private List<Music> listOfSongs = new List<Music>();
        private int length;
        private string singer;
        private int amountOfSongs;

        public string Name { get { return name; } set { this.name = value; } }
        public List<Music> Songs { get { return listOfSongs; } set { listOfSongs = value; } }

        public Album(string name , int length, string singer, int amountOfSongs)
        {
            this.Name = name;
            this.length = length;
            this.singer = singer;
            this.amountOfSongs = amountOfSongs;
        }
        public void addSong(Music music)    // nummer toevoegen aan list
        {
            listOfSongs.Add(music);
        }

        public Music getSongFromAlbum(int i)    // haal music object uit list
        {
            Console.WriteLine(this.Songs[i].Name);
            return this.Songs[i];

        }
        public void playAlbum() // album afspelen
        {
            int i = 0;
            int j = 0;
            Music selected_Song = this.Songs[i];
            Console.WriteLine(selected_Song.Name);
            int amountOfSongs = this.Songs.Count;
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
                        selected_Song = this.getSongFromAlbum(i);
                        songLength = selected_Song.Length;
                        j = 0;

                    }
                }

                Console.WriteLine("Klik op escape om terug te gaan");
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)   // muziek pauzeren
                {
                    Console.WriteLine("Klik op spatie om het nummer door te spelen");
                }



            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);   // muziek afsluiten
        }

        public void albumRandomOrder() // muziek in random volgorde afspelen
        {
            int i = 0;
            int j = 0;
            Random rnd = new Random();

            Music selected_Song = this.Songs[i];
            Console.WriteLine(selected_Song.Name);

            int amountOfSongs = this.Songs.Count;
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
                        selected_Song = this.Songs[i];
                        songLength = selected_Song.Length;
                        j = 0;

                    }
                }

                Console.WriteLine("Klik op escape om terug te gaan");   // muziek pauzeren
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("Klik op spatie om het nummer door te spelen");
                }



            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);   // muziek stoppen
        }
    }
}
