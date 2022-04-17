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

            Music nummer1 = new Music("song1",5,"name","genre1");
            Music nummer2 = new Music("song2", 10, "name2", "genre2");
            Music nummer3 = new Music("song3", 3, "name3", "genre3");
            Music nummer4 = new Music("song4", 2, "name4", "genre4");
            Album album1 = new Album("naam",260,"zanger",2);
            album1.addSong(nummer1);
            album1.addSong(nummer2);
            Playlist allAlbums = new Playlist("Allalbums");
            allAlbums.addAlbum(album1);

            Person name = new Person("Renzo");
            Friendlist allePersonen = new Friendlist();
            allePersonen.addFriend(name);
            Friendlist friendlist = new Friendlist();
            Playlist alleMuziek = new Playlist("allMusic");

            alleMuziek.addsong(nummer1);
            alleMuziek.addsong(nummer2);
            alleMuziek.addsong(nummer3);
            alleMuziek.addsong(nummer4);

            PlaylistLibrary musicHolder = new PlaylistLibrary(name);
            Playlist testList = new Playlist("test");
            testList.addsong(nummer1);
            testList.addsong(nummer2);
            testList.addsong(nummer3);
            testList.addsong(nummer4);


            musicHolder.createPlaylist(testList);
            name.Playlistlibraries = musicHolder;
            name.Friendslist = friendlist;
            string input = "start";

            while (input != "stop" )
            {
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
                            Console.WriteLine("Je moet een playlist kiezen");
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
                                    Console.WriteLine("type speellijst maken om een nieuwe speellijst te maken");
                                    Console.WriteLine("type afspelen om een afspeellijst af te spelen");
                                    Console.WriteLine("Type delete om de speellijst te verwijderen");
                                    input = Console.ReadLine();
                                    if (input == "toevoegen")
                                    {
                                        while (input != "terug") { 
                                            Console.WriteLine("Type terug om terug te gaan");
                                            Console.WriteLine("type nummer om een nummer toe te voegen");
                                            Console.WriteLine("Type album om een album toe te voegen");
                                            input = Console.ReadLine();
                                            if (input == "nummer")
                                            {
                                                alleMuziek.readList();
                                                Console.WriteLine("Kies een nummer om toe te voegen");

                                                input = Console.ReadLine();
                                                Music selected_Song = alleMuziek.getSongName(input);
                                                if (selected_Song != null)
                                                {
                                                    selected_playlist.addsong(selected_Song);
                                                    Console.WriteLine("Nummer is toegevoegd aan afspeellijst");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Nummer bestaat niet");
                                                }
                                            }
                                            else if (input == "album")
                                            {
                                                allAlbums.readListAlbum();
                                                Console.WriteLine("Kies een album om toe te voegen");

                                                input = Console.ReadLine();
                                                Album selected_album = allAlbums.getAlbumName(input);
                                                if (selected_album != null)
                                                {
                                                    selected_playlist.addAlbumToPlaylist(selected_album);
                                                    Console.WriteLine("Album is toegevoegd");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Album bestaat niet");
                                                }
                                            }
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
                                        if (selected_playlist.Songlist.Count != 0) { 
                                        int i = 0;
                                        int j = 0;
                                        Console.WriteLine("Klik op spatie om de muziek te pauzeren");
                                        Console.WriteLine("Wil je de afspeellijst in random volgorde afspelen?");
                                        Console.WriteLine("Type ja voor random volgorde");
                                        Console.WriteLine("type nee om de standaard volgorde af te spelen");
                                        input = Console.ReadLine().ToLower();
                                        if (input == "ja")
                                        {
                                            selected_playlist.musicRandomOrder(i, j);
                                        }
                                        else if (input == "nee")
                                        {
                                            selected_playlist.musicNormalOrder(i, j);
                                        }
                                    }
                                        else
                                        {
                                            Console.WriteLine("er staan geen nummers in de afspeellijst voeg eerst nummers toe");
                                        }
                                }
                                    else if (input == "speellijst maken")
                                    {
                                        Console.WriteLine("Geef een naam voor de speellijst");
                                        input = Console.ReadLine();

                                        Playlist newList = new Playlist(input);
                                        musicHolder.createPlaylist(newList);
                                    }
                                    else if (input == "delete")
                                    {
                                        musicHolder.deletePlaylist(selected_playlist);
                                        input = "terug";
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
                        input = Console.ReadLine().ToLower();
                        if (input == "ja")
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
                                    selected_Song.playsong();
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
                        Console.WriteLine("Type terug om terug te gaan");
                        Console.WriteLine("Type zoeken om te zoeken naar vrienden");
                        Console.WriteLine("Type vrienden om je vriendenlijst in te zien");
                        Console.WriteLine("Type verzoeken om je vriend verzoeken in te zien");
                        input = Console.ReadLine();
                        if ( input == "verzoeken")
                        {
                            friendlist.vriendVerzoeken();
                            Console.WriteLine("Kies een naam om toe te voegen of verwijderen");
                            input = Console.ReadLine();
                            if (input != null)
                            {
                                Person selectedPerson = allePersonen.searchFriends(input);
                                Console.WriteLine("Type verwijderen om de persoon te weigeren");
                                Console.WriteLine("Type toevoegen om de persoon toe te voegen aan je vriendenlijst");
                                input = Console.ReadLine();

                                if (input == "verwijderen")
                                {
                                    friendlist.verwijderVerzoeken(selectedPerson);
                                    Console.WriteLine("Verzoek is verwijderd");

                                }
                                else if (input == "toevoegen")
                                {
                                    friendlist.verwijderVerzoeken(selectedPerson);
                                    friendlist.addFriend(selectedPerson);
                                    Console.WriteLine("Vriend is toegevoegd aan vriendenlijst");

                                }
                            }

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
                                    Console.WriteLine("Kies een vriend om zijn speellijsten in te zien");
                                    input = Console.ReadLine();
                                    if (input != null) { 
                                    Person selectedPerson = allePersonen.searchFriends(input);
                                        if (selectedPerson != null)
                                        { 
                                            Console.WriteLine("Type inzien om de speellijsten in te zien");
                                            Console.WriteLine("Type afspelen om de speellijst af te spelen");
                                            Console.WriteLine("Type kopieren om de speellijst te kopiëren");

                                            input = Console.ReadLine();

                                            if (input == "inzien")
                                            {
                                                Console.WriteLine(selectedPerson.Playlistlibraries);
                                            }
                                            else if (input == "afspelen")
                                            {
                                                Console.WriteLine(selectedPerson.Playlistlibraries);
                                                Console.WriteLine("Kies een afspeellijst");
                                                input = Console.ReadLine();
                                                if (input != null)
                                                {
                                                    PlaylistLibrary selectedLibrary = selectedPerson.Playlistlibraries;
                                                    Playlist selectedPlaylist = selectedLibrary.getSelectedPlaylist(input);
                                                    int i = 0;
                                                    int j = 0;
                                                    Console.WriteLine("Klik op spatie om de muziek te pauzeren");
                                                    Console.WriteLine("Wil je de afspeellijst in random volgorde afspelen?");
                                                    Console.WriteLine("Type ja voor random volgorde");
                                                    Console.WriteLine("type nee om de standaard volgorde af te spelen");
                                                    input = Console.ReadLine().ToLower();
                                                    if (input == "ja")
                                                    {
                                                        selectedPlaylist.musicRandomOrder(i, j);
                                                    }
                                                    else if (input == "nee")
                                                    {
                                                        selectedPlaylist.musicNormalOrder(i, j);
                                                    }
                                                }
                                            }
                                            else if (input == "kopieren")
                                            {
                                                Console.WriteLine(selectedPerson.Playlistlibraries);
                                                Console.WriteLine("Kies een afspeellijst");
                                                input = Console.ReadLine();
                                                if (input != null)
                                                {
                                                    PlaylistLibrary selectedLibrary = selectedPerson.Playlistlibraries;
                                                    Playlist selectedPlaylist = selectedLibrary.getSelectedPlaylist(input);
                                                    musicHolder.createPlaylist(selectedPlaylist);
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (input == "zoeken")
                        {
                            Console.WriteLine("Zoek een persoon op");
                            input = Console.ReadLine();
                            if (input != null)
                            {
                                Person selectedPerson = allePersonen.searchFriends(input);
                                if (selectedPerson != null)
                                {
                                    Console.WriteLine("Wil je een verzoek versturen?");
                                    Console.WriteLine("Type ja om een verzoek te sturen");
                                    input = Console.ReadLine();
                                    if (input == "ja")
                                    {
                                        Friendlist selectedFriendlist = selectedPerson.Friendslist;
                                        selectedFriendlist.addFriend(name);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Persoon is niet gevonden");
                                }
                            }

                        }

                    }
                }
            }
        }
    }
}