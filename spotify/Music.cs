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
        public int Length { get { return length; } set { this.length = value; } }
        public Music(string name, int length, string artist , string genre)
        {
            this.name = name;
            this.length = length;   
            this.artist = artist;
            this.genre = genre;
        }

        public void playsong()
        {
            int j = 0;
            
                Music selected_Song = this;
                Console.WriteLine(selected_Song.Name);
            int songLength = this.length;

                do
                {
                    while (!Console.KeyAvailable)
                    {
                        System.Threading.Thread.Sleep(1000);
                        j++;
                    }

                    Console.WriteLine("Klik op escape om terug te gaan");
                    if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    {
                        Console.WriteLine("Klik op spatie om het nummer door te spelen");
                    }



                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

    }
}
