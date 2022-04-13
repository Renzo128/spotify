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

            Person name = new Person("Renzo");
            Friendlist friendlist = new Friendlist();
            Playlist alleMuziek = new Playlist("allMusic");

            alleMuziek.addsong(nummer1);
            alleMuziek.addsong(nummer2);
            alleMuziek.addsong(nummer3);
            alleMuziek.addsong(nummer4);

            PlaylistLibrary musicHolder = new PlaylistLibrary(name);
            Playlist testList = new Playlist("test");
            musicHolder.createPlaylist(testList);
            name.Playlistlibraries = musicHolder;
            name.Friendslist = friendlist;
            string input = "start";

            while (input != "stop" )
            {
                Console.WriteLine("\n");
                Console.WriteLine("*****************************************************************");
                Console.WriteLine("type speellijst om naar playlist te gaan");
                Console.WriteLine("type zoeken om muziek te zoeken te gaan");
                Console.WriteLine("type vriendenlijst om naar vriendenlijst te gaan");
                Console.WriteLine("type stop om te stoppen");

                input = Console.ReadLine();
                Console.WriteLine("\n");
                if(input == "speellijst")
                {   // eigen afspeellijsten inkijken
                    int length = musicHolder.getAllPlaylists().Count;
                    if (length != 0)
                    {
                        musicHolder.readList();

                        Console.WriteLine("Kies een playlist");
                        input = Console.ReadLine();
                        if (input == null)
                        {
                        }
                        else
                        {
                            if (musicHolder.getPlaylistName(input) == true)
                            {
                                Playlist selected_playlist = musicHolder.getSelectedPlaylist(input);
                                while (input != "terug")
                                {
                                    Console.WriteLine("type terug om terug te gaan");
                                    Console.WriteLine("type toevoegen om een nummer/album toe te voegen");
                                    Console.WriteLine("type verwijderen om een nummer te verwijderen");
                                    Console.WriteLine("type speel lijst maken om een nieuwe speellijst te maken");
                                    Console.WriteLine("type afspelen om een afspeellijst af te spelen");
                                    input = Console.ReadLine();
                                    if (input == "toevoegen")
                                    {

                                        alleMuziek.readList();
                                        Console.WriteLine("Kies een nummer om toe te voegen");

                                        input = Console.ReadLine();
                                        Music selected_Song = alleMuziek.getSongName(input);
                                        if (selected_Song != null)
                                        {
                                            selected_playlist.addsong(selected_Song);
                                        }
                                    }
                                    else if (input == "verwijderen")
                                    {
                                        selected_playlist.readList();
                                        Console.WriteLine("Kies een nummer om te verwijderen");

                                        input = Console.ReadLine();
                                        Music selected_Song = alleMuziek.getSongName(input);
                                        if (selected_Song != null)
                                        {
                                            selected_playlist.removeSong(selected_Song);
                                        }
                                    }
                                    else if (input == "afspelen")
                                    {
                                        // nummer afspelen
                                    }
                                    else if (input == "speellijst maken")
                                    {
                                        Console.WriteLine("Geef een naam voor de speellijst");
                                        input = Console.ReadLine();

                                        Playlist newList = new Playlist(input);
                                        musicHolder.createPlaylist(newList);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("speellijst bestaat niet");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wil je een nieuwe speellijst maken?");
                        Console.WriteLine("Ja / Nee");
                        input = Console.ReadLine();
                        if (input == "Ja")
                        {
                            Console.WriteLine("Geef een naam voor de speellijst");
                            input = Console.ReadLine();

                            Playlist newList = new Playlist(input);
                            musicHolder.createPlaylist(newList);
                        }
                    }

                }



                else if (input == "zoeken")
                { // muziek zoeken
                    while (input != "terug")
                    {
                        Console.WriteLine("type terug om terug te gaan");
                        Console.WriteLine("type zoeken om te zoeken");

                        input = Console.ReadLine();
                        if (input == "zoeken")
                        {
                            //alleMuziek.readList();
                            Console.WriteLine("Zoek een nummer");

                            input = Console.ReadLine();
                            Music selected_Song = alleMuziek.getSongName(input);
                            if (selected_Song != null)
                            {
                                Console.WriteLine(selected_Song.Name + " is gevonden");
                                Console.WriteLine("type afspelen om het nummer af te spelen");
                                Console.WriteLine("type toevoegen om een nummer toe te voegen aan een afspeellijst");
                                input = Console.ReadLine(); 
                                if (input == "afspelen")
                                {
                                    // nummer afspelen
                                }
                                if (input == "toevoegen")
                                {

                                    musicHolder.readList();

                                    Console.WriteLine("Kies een playlist");
                                    input = Console.ReadLine();
                                    if (musicHolder.getPlaylistName(input) == true)
                                    {
                                        Playlist selected_playlist = musicHolder.getSelectedPlaylist(input);
                                        if (selected_Song != null)
                                        {
                                            selected_playlist.addsong(selected_Song);
                                        }
                                    }
                                }

                            }
                        }

                    }
                }



                else if(input == "vriendenlijst")
                {   // vriendenlijst inkijken
                    while (input != "terug")
                    {
                        Console.WriteLine("type terug om terug te gaan");
                        input = Console.ReadLine();
                        if ( input == "verzoeken")
                        {

                        }
                        else if(input == "vrienden")
                        {
                            Console.WriteLine("selecteer een vriend");
                            input = Console.ReadLine();
                            if (input != null)
                            {
                                Console.WriteLine("Type speellijst om zijn speellijsten in te zien");
                                Console.WriteLine("Type verwijderen om de vriend te verwijderen");
                                input = Console.ReadLine();
                                if (input == "verwijderen")
                                {
                                    Console.WriteLine("Welke vriend wil je verwijderen?");
                                    input = Console.ReadLine();
                                    if (input != null)
                                    {
                                        friendlist.removeFriend(input);
                                    }
                                }
                                else if (input == "speellijst")
                                {
                                    Console.WriteLine("Type inzien om de speellijsten in te zien");
                                    Console.WriteLine("Type afspelen om de speellijst af te spelen");
                                    Console.WriteLine("Type kopieren om de speellijst te kopiëren");

                                    input = Console.ReadLine();

                                    if (input == "inzien")
                                    {

                                    }
                                    else if(input == "afspelen")
                                    {

                                    }
                                    else if(input == "kopieren")
                                    {

                                    }
                                }

                            }




                        }

                    }
                }
            }
        }
    }
}