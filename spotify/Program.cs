using System;
using album;
using friendlist;
using music;
using person;
using playlist;
using playlistlibrary;
namespace Spotify{ 
    class spotify
    {

    // Main Method
        static public void Main(String[] args)
        {
            Music nummer1 = new Music("song1",80,"name","genre1");
            Music nummer2 = new Music("song2", 180, "name2", "genre2");
            Music nummer3 = new Music("song3", 150, "name3", "genre3");
            Music nummer4 = new Music("song4", 90, "name4", "genre4");
            string input = "start";

            while (input != "stop" )
            {
                Console.WriteLine("\n");
                Console.WriteLine("*****************************************************************");
                Console.WriteLine("type playlist om naar playlist te gaan");
                Console.WriteLine("type zoeken om muziek te zoeken te gaan");
                Console.WriteLine("type vriendenlijst om naar vriendenlijst te gaan");
                Console.WriteLine("type stop om te stoppen");

                input = Console.ReadLine();
                Console.WriteLine("\n");
                if(input == "playlist")
                {   // eigen afspeellijsten inkijken
                    while (input != "terug") { 
                    Console.WriteLine("Ik ben hier");
                        Console.WriteLine("type terug om terug te gaan");
                        input = Console.ReadLine();
                        if (input == "toevoegen")
                        {

                        }
                        else if (input == "verwijderen")
                        {

                        }
                        else if (input == "afspelen")
                        {

                        }
                    }
                }
                else if (input == "zoeken")
                { // muziek zoeken
                    while (input != "terug")
                    {
                        Console.WriteLine("ik ben hier 2");
                        Console.WriteLine("type terug om terug te gaan");
                        input = Console.ReadLine();
                        if (input == "zoeken")
                        {

                        }

                    }
                }
                else if(input == "vriendenlijst")
                {   // vriendenlijst inkijken
                    while (input != "terug")
                    {
                        Console.WriteLine("ik ben hier 3");
                        Console.WriteLine("type terug om terug te gaan");
                        input = Console.ReadLine();
                        if ( input == "verzoeken")
                        {

                        }
                        else if(input == "vrienden")
                        {

                        }

                    }
                }
            }
        }
    }
}