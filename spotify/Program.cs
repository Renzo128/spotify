using System;
using album;
using friendlist;
using music;
using person;
using playlist;
using library;
namespace Spotify{ 
    class spotify
    {

    // Main Method
        static public void Main(String[] args)
        {
            Person admin = new Person("Admin");
            Music nummer1 = new Music("song1",5,"name","genre1");
            Music nummer2 = new Music("song2", 10, "name2", "genre2");
            Music nummer3 = new Music("song3", 3, "name3", "genre3");
            Music nummer4 = new Music("song4", 2, "name4", "genre4");
            Album album1 = new Album("naam",260,"zanger",2);
            album1.addSong(nummer1);
            album1.addSong(nummer2);
            Library allAlbums = new Library(admin);
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

            Library musicHolder = new Library(name);
            Playlist testList = new Playlist("test");
            testList.addsong(nummer1);
            testList.addsong(nummer2);
            testList.addsong(nummer3);
            testList.addsong(nummer4);


            musicHolder.createPlaylist(testList);
            name.Playlistlibraries = musicHolder;
            name.Friendslist = friendlist;
            string input = "start";
            string input2 = "start";
            string input3 = "start";
            string input4 = "start";


            while (input != "stop" )
            {
                input2 = "";
                Console.WriteLine("type speellijst om naar playlist te gaan");
                Console.WriteLine("type zoeken om muziek te zoeken te gaan");
                Console.WriteLine("type vriendenlijst om naar vriendenlijst te gaan");
                Console.WriteLine("type stop om te stoppen");

                input = Console.ReadLine().ToLower();
                Console.WriteLine("\n");
                if(input == "speellijst")
                {   // eigen afspeellijsten inkijken
                    int length = musicHolder.getAllPlaylists().Count;
                    if (length != 0)
                    {

                        while (input2 != "terug")
                        {
                            musicHolder.readList();
                            Console.WriteLine("Kies een speellijst");
                            Console.WriteLine("Type terug om terug te gaan");
                            input2 = Console.ReadLine().ToLower();
                            if (input2 == null)
                            {
                                Console.WriteLine("Je moet een speellijst kiezen");
                            }
                            else
                            {
                                if (musicHolder.getPlaylistName(input2) == true)
                                {
                                    Playlist selected_playlist = musicHolder.getSelectedPlaylist(input2);
                                    while (input2 != "terug")
                                    {
                                        Console.WriteLine("\n");
                                        Console.WriteLine("type terug om terug te gaan");
                                        Console.WriteLine("type toevoegen om een nummer/album toe te voegen");
                                        Console.WriteLine("type verwijderen om een nummer te verwijderen");
                                        Console.WriteLine("type speellijst maken om een nieuwe speellijst te maken");
                                        Console.WriteLine("type afspelen om een afspeellijst af te spelen");
                                        Console.WriteLine("Type delete om de speellijst te verwijderen");
                                        input2 = Console.ReadLine().ToLower();
                                        if (input2 == "toevoegen")
                                        {
                                            input3 = "";
                                            while (input3 != "terug")
                                            {
                                                Console.WriteLine("\n");
                                                Console.WriteLine("Type terug om terug te gaan");
                                                Console.WriteLine("type nummer om een nummer toe te voegen");
                                                Console.WriteLine("Type album om een album toe te voegen");
                                                input3 = Console.ReadLine().ToLower();
                                                Console.WriteLine("\n");
                                                if (input3 == "nummer")
                                                {
                                                    alleMuziek.readList();
                                                    Console.WriteLine("Kies een nummer om toe te voegen");
                                                    Console.WriteLine("Type terug om terug te gaan");

                                                    input4 = Console.ReadLine();
                                                    Music selected_Song = alleMuziek.getSongName(input4);
                                                    Music songIsInPlaylist = selected_playlist.getSongName(input4);

                                                    if (input4 == "terug")
                                                    {

                                                    }
                                                    else if (songIsInPlaylist != null)
                                                    {
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("nummer staat al in afspeellijst");
                                                    }
                                                    else if (selected_Song != null && songIsInPlaylist == null)
                                                    {
                                                        Console.WriteLine("\n");
                                                        selected_playlist.addsong(selected_Song);
                                                        Console.WriteLine("Nummer is toegevoegd aan afspeellijst");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("Nummer bestaat niet");
                                                    }
                                                }
                                                else if (input3 == "album")
                                                {
                                                    allAlbums.readListAlbum();
                                                    Console.WriteLine("Kies een album om toe te voegen");
                                                    Console.WriteLine("Type terug om terug te gaan");

                                                    input4 = Console.ReadLine().ToLower();
                                                    Album selected_album = allAlbums.getAlbumName(input4);
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
                                                else
                                                {
                                                    Console.WriteLine("Kies tussen album of nummer om muziek toe te voegen");
                                                }
                                            }
                                        }
                                        else if (input2 == "verwijderen")
                                        {
                                            input3 = "";
                                            while (input3 != "terug")
                                            {
                                                Console.WriteLine("\n");
                                                selected_playlist.readList();
                                                Console.WriteLine("Kies een nummer om te verwijderen");
                                                Console.WriteLine("Type terug om terug te gaan");
                                                input3 = Console.ReadLine().ToLower();
                                                Music selected_Song = alleMuziek.getSongName(input3);
                                                Console.WriteLine("\n");
                                                if (input3 == "terug")
                                                {

                                                }
                                                else if (selected_Song != null)
                                                {
                                                    selected_playlist.removeSong(selected_Song);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Nummer heeft niet in afspeellijst gestaan");
                                                }
                                            }
                                        }
                                        else if (input2 == "afspelen")
                                        {
                                            input3 = "";
                                            while (input3 != "terug")
                                            {
                                                if (selected_playlist.Songlist.Count != 0)
                                                {
                                                    int i = 0;
                                                    int j = 0;
                                                    Console.WriteLine("\n");
                                                    Console.WriteLine("Klik op spatie om de muziek te pauzeren");
                                                    Console.WriteLine("Wil je de afspeellijst in random volgorde afspelen?");
                                                    Console.WriteLine("Type ja voor random volgorde");
                                                    Console.WriteLine("type nee om de standaard volgorde af te spelen");
                                                    Console.WriteLine("Type terug om terug te gaan");
                                                    input3 = Console.ReadLine().ToLower();
                                                    Console.WriteLine("\n");
                                                    if (input3 == "ja")
                                                    {
                                                        selected_playlist.musicRandomOrder(i, j);
                                                    }
                                                    else if (input3 == "nee")
                                                    {
                                                        selected_playlist.musicNormalOrder(i, j);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n");
;                                                    Console.WriteLine("er staan geen nummers in de afspeellijst voeg eerst nummers toe");
                                                    input3 = "terug";
                                                }
                                            }
                                        }
                                        else if (input2 == "speellijst maken")
                                        {
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Geef een naam voor de speellijst");
                                            Console.WriteLine("Type terug om geen afspeellijst te maken");
                                            input2 = Console.ReadLine().ToLower();
                                            Console.WriteLine("\n");
                                            if (input2 != "terug")
                                            {
                                                if (musicHolder.getSelectedPlaylist(input2) == null)
                                                {
                                                    Playlist newList = new Playlist(input2);
                                                    musicHolder.createPlaylist(newList);
                                                    Console.WriteLine("Nieuwe speellijst is gemaakt");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("afspeellijst naam bestaat al");
                                                }
                                            }
                                        }
                                        else if (input2 == "delete")
                                        {
                                            musicHolder.deletePlaylist(selected_playlist);
                                            input2 = "terug";
                                            Console.WriteLine("\n");
                                            Console.WriteLine("afspeellijst is verwijderd");
                                            Console.WriteLine("\n");

                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("speellijst bestaat niet");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wil je een nieuwe speellijst maken?");
                        Console.WriteLine("ja / nee");
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

                        input = Console.ReadLine().ToLower();
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
                                input = Console.ReadLine().ToLower(); 
                                if (input == "afspelen")
                                {
                                    selected_Song.playsong();
                                }
                                else if (input == "toevoegen")
                                {

                                    musicHolder.readList();

                                    Console.WriteLine("Kies een afspeellijst.");
                                    input = Console.ReadLine().ToLower();
                                    if (musicHolder.getPlaylistName(input) == true)
                                    {
                                        Playlist selected_playlist = musicHolder.getSelectedPlaylist(input);
                                        if (selected_Song != null)
                                        {
                                            selected_playlist.addsong(selected_Song);
                                            Console.WriteLine("nummer is toegevoegd.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nummer bestaat niet.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n");
                                        Console.WriteLine("de gekozen afspeellijst bestaat niet.");
                                        Console.WriteLine("\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Kies tussen toevoegen of afspelen.");
                                    Console.WriteLine("\n");
                                }

                            }
                            else
                            {
                                Console.WriteLine("\n");
                                Console.WriteLine("Nummer bestaat niet.");
                                Console.WriteLine("\n");
                            }
                        }
                        else if(input != "terug")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Type zoeken of terug.");
                            Console.WriteLine("\n");
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
                        input = Console.ReadLine().ToLower();
                        if ( input == "verzoeken")
                        {
                            input2 = "";
                            while (input2 != "terug")
                            {
                                friendlist.vriendVerzoeken();
                                Console.WriteLine("Kies een naam om toe te voegen of verwijderen");
                                Console.WriteLine("Kies terug om terug te gaan.");
                                input2 = Console.ReadLine().ToLower();
                                if (input2 != null)
                                {
                                    Person selectedPerson = allePersonen.searchFriends(input2);
                                    Console.WriteLine("Type verwijderen om de persoon te weigeren");
                                    Console.WriteLine("Type toevoegen om de persoon toe te voegen aan je vriendenlijst");
                                    Console.WriteLine("type terug om terug te gaan");
                                    input2 = Console.ReadLine().ToLower();

                                    if (input2 == "verwijderen")
                                    {
                                        friendlist.verwijderVerzoeken(selectedPerson);
                                        Console.WriteLine("Verzoek is verwijderd");

                                    }
                                    else if (input2 == "toevoegen")
                                    {
                                        friendlist.verwijderVerzoeken(selectedPerson);
                                        friendlist.addFriend(selectedPerson);
                                        Console.WriteLine("Vriend is toegevoegd aan vriendenlijst");
                                    }
                                    else if(input2 != "terug")
                                    {
                                        Console.WriteLine("Kies verwijderen , toevoegen of terug");
                                    }
                                }
                                else if(input2 != "terug")
                                {
                                    Console.WriteLine("Kies een persoon of kies om terug te gaan.");
                                }
                            }
                        }
                        else if(input == "vrienden")
                        {
                            Console.WriteLine("selecteer een vriend");
                            input = Console.ReadLine().ToLower();
                            if (input != null)
                            {
                                Console.WriteLine("Type speellijst om zijn speellijsten in te zien");
                                Console.WriteLine("Type verwijderen om de vriend te verwijderen");
                                input = Console.ReadLine().ToLower();
                                if (input == "verwijderen")
                                {
                                    Console.WriteLine("Welke vriend wil je verwijderen?");
                                    input = Console.ReadLine().ToLower();
                                    if (input != null)
                                    {
                                        friendlist.removeFriend(input);
                                    }
                                }
                                else if (input == "speellijst")
                                {
                                    Console.WriteLine("Kies een vriend om zijn speellijsten in te zien");
                                    input = Console.ReadLine().ToLower();
                                    if (input != null) { 
                                    Person selectedPerson = allePersonen.searchFriends(input);
                                        if (selectedPerson != null)
                                        { 
                                            Console.WriteLine("Type inzien om de speellijsten in te zien");
                                            Console.WriteLine("Type afspelen om de speellijst af te spelen");
                                            Console.WriteLine("Type kopieren om de speellijst te kopiëren");

                                            input = Console.ReadLine().ToLower();

                                            if (input == "inzien")
                                            {
                                                Console.WriteLine(selectedPerson.Playlistlibraries);
                                            }
                                            else if (input == "afspelen")
                                            {
                                                Console.WriteLine(selectedPerson.Playlistlibraries);
                                                Console.WriteLine("Kies een afspeellijst");
                                                input = Console.ReadLine().ToLower();
                                                if (input != null)
                                                {
                                                    Library selectedLibrary = selectedPerson.Playlistlibraries;
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
                                                input = Console.ReadLine().ToLower();
                                                if (input != null)
                                                {
                                                    Library selectedLibrary = selectedPerson.Playlistlibraries;
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
                            input = Console.ReadLine().ToLower();
                            if (input != null)
                            {
                                Person selectedPerson = allePersonen.searchFriends(input);
                                if (selectedPerson != null)
                                {
                                    Console.WriteLine("Wil je een verzoek versturen?");
                                    Console.WriteLine("Type ja om een verzoek te sturen");
                                    input = Console.ReadLine().ToLower();
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
                        else
                        {
                            Console.WriteLine("Kies vrienden , zoeken of verzoeken.");
                        }

                    }
                }
            }
        }
    }
}