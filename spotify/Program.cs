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
            Person admin = new Person("Admin");     // objecten aanmaken
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
            string input5 = "start";
            string input6 = "start";


            Person test1 = new Person("test1");
            Person test2 = new Person("test2");
            Person test3 = new Person("test3");
            allePersonen.addFriend(test1);
            allePersonen.addFriend(test2);
            allePersonen.addFriend(test3);

            Library testHolder = new Library(test1);
            Playlist testListTest = new Playlist("asdf");
            testListTest.addsong(nummer1);
            testHolder.createPlaylist(testListTest);
            test1.Playlistlibraries = testHolder;
            Friendlist friendlist2 = new Friendlist();
            Friendlist friendlist3 = new Friendlist();
            Friendlist friendlist4 = new Friendlist();

            test1.Friendslist = friendlist2;
            test2.Friendslist = friendlist3;
            test3.Friendslist = friendlist4;
            name.Friendslist.addFriend(test1);
            name.Friendslist.stuurVerzoek(test2);
            name.Friendslist.stuurVerzoek(test3);

            while (input != "stop" )    // begin programma
            {
                input2 = "";
                Console.WriteLine("type stop om te stoppen.");
                Console.WriteLine("type speellijst om naar playlist te gaan.");
                Console.WriteLine("type zoeken om muziek te zoeken te gaan.");
                Console.WriteLine("type vriendenlijst om naar vriendenlijst te gaan.");

                input = Console.ReadLine().ToLower();
                Console.WriteLine("\n");
                if(input == "speellijst")   // speellijsten maken updaten verwijderen
                {   // eigen afspeellijsten inkijken
                    int length = musicHolder.getAllPlaylists().Count;
                    if (length != 0)
                    {
                        input5 = "";
                        while (input5 != "terug")
                        {
                            musicHolder.readList();
                            Console.WriteLine("Type terug om terug te gaan.");
                            Console.WriteLine("Kies een speellijst.");
                            input5 = Console.ReadLine().ToLower();
                            Console.WriteLine("\n");

                            if (input5 == null)
                            {
                                Console.WriteLine("Je moet een speellijst kiezen.");
                            }
                            else
                            {
                                if (musicHolder.getPlaylistName(input5) == true)
                                {
                                    input2 = "";
                                    Playlist selected_playlist = musicHolder.getSelectedPlaylist(input5);
                                    while (input2 != "terug")
                                    {
                                        Console.WriteLine("type terug om terug te gaan.");
                                        Console.WriteLine("type toevoegen om een nummer/album toe te voegen.");
                                        Console.WriteLine("type verwijderen om een nummer te verwijderen.");
                                        Console.WriteLine("type maken om een nieuwe speellijst te maken.");
                                        Console.WriteLine("type afspelen om een afspeellijst af te spelen.");
                                        Console.WriteLine("Type delete om de speellijst te verwijderen.");
                                        input2 = Console.ReadLine().ToLower();
                                        Console.WriteLine("\n");


                                        if (input2 == "toevoegen")  // muziek toevoegen aan afspeellijst
                                        {
                                            input3 = "";
                                            while (input3 != "terug")
                                            {
                                                Console.WriteLine("Type terug om terug te gaan.");
                                                Console.WriteLine("type nummer om een nummer toe te voegen.");
                                                Console.WriteLine("Type album om een album toe te voegen.");
                                                input3 = Console.ReadLine().ToLower();
                                                Console.WriteLine("\n");
                                                if (input3 == "nummer")
                                                {
                                                    alleMuziek.readList();
                                                    Console.WriteLine("\n");
                                                    Console.WriteLine("Type terug om terug te gaan.");
                                                    Console.WriteLine("Kies een nummer om toe te voegen.");

                                                    input4 = Console.ReadLine();
                                                    Console.WriteLine("\n");

                                                    if (input4 != null)
                                                    {
                                                        Music selected_Song = alleMuziek.getSongName(input4);
                                                        Music songIsInPlaylist = selected_playlist.getSongName(input4);
                                                        if (input4 == "terug")
                                                        {

                                                        }
                                                        else if (songIsInPlaylist != null)
                                                        {
                                                            Console.WriteLine("\n");
                                                            Console.WriteLine("nummer staat al in afspeellijst.");
                                                            Console.WriteLine("\n");

                                                        }
                                                        else if (selected_Song != null && songIsInPlaylist == null)
                                                        {
                                                            Console.WriteLine("\n");
                                                            selected_playlist.addsong(selected_Song);
                                                            Console.WriteLine("Nummer is toegevoegd aan afspeellijst.");
                                                            Console.WriteLine("\n");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("\n");
                                                            Console.WriteLine("Nummer bestaat niet.");
                                                            Console.WriteLine("\n");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Er kunnen geen lege waardes gezocht worden.");
                                                        Console.WriteLine("\n");
                                                    }
                                                }
                                                else if (input3 == "album")
                                                {
                                                    allAlbums.readListAlbum();
                                                    Console.WriteLine("Type terug om terug te gaan.");
                                                    Console.WriteLine("Kies een album om toe te voegen.");

                                                    input4 = Console.ReadLine().ToLower();
                                                    Console.WriteLine("\n");
                                                    if (input4 != null)
                                                    {
                                                        Album selected_album = allAlbums.getAlbumName(input4);
                                                        if (selected_album != null)
                                                        {
                                                            selected_playlist.addAlbumToPlaylist(selected_album);
                                                            Console.WriteLine("Album is toegevoegd.");
                                                            Console.WriteLine("\n");

                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Album bestaat niet.");
                                                            Console.WriteLine("\n");

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Er kunnen geen lege waardes gezocht worden.");
                                                        Console.WriteLine("\n");

                                                    }
                                                }
                                                else if(input3 != "terug")
                                                {
                                                    Console.WriteLine("Kies tussen album of nummer om een nummer toe te voegen.");
                                                    Console.WriteLine("\n");
                                                }
                                            }
                                        }
                                        else if (input2 == "verwijderen")   // muziek verwijderen uit afspeellijst
                                        {
                                            input3 = "";
                                            while (input3 != "terug")
                                            {
                                                selected_playlist.readList();
                                                Console.WriteLine("Type terug om terug te gaan.");
                                                Console.WriteLine("Kies een nummer om te verwijderen.");
                                                input3 = Console.ReadLine().ToLower();

                                                Console.WriteLine("\n");
                                                if (input3 == "terug")
                                                {

                                                }
                                                else if (input3 != null)
                                                {
                                                    Music selected_Song = selected_playlist.getSongName(input3);
                                                    if (selected_Song != null)
                                                    {
                                                        selected_playlist.removeSong(selected_Song);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Nummer heeft niet in afspeellijst gestaan.");

                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Er kunnen geen lege waardes gezocht worden.");
                                                }
                                            }
                                        }
                                        else if (input2 == "afspelen")  // muziek afspelen
                                        {
                                            input3 = "";
                                            while (input3 != "terug")
                                            {
                                                if (selected_playlist.Songlist.Count != 0)
                                                {
                                                    int i = 0;
                                                    int j = 0;
                                                    Console.WriteLine("\n");
                                                    Console.WriteLine("Type terug om terug te gaan.");
                                                    Console.WriteLine("Klik op spatie om de muziek te pauzeren.");
                                                    Console.WriteLine("Wil je de afspeellijst in random volgorde afspelen?");
                                                    Console.WriteLine("Type ja voor random volgorde.");
                                                    Console.WriteLine("type nee om de standaard volgorde af te spelen.");

                                                    input3 = Console.ReadLine().ToLower();
                                                    Console.WriteLine("\n");
                                                    if (input3 == "ja")
                                                    {
                                                        selected_playlist.musicRandomOrder();
                                                    }
                                                    else if (input3 == "nee")
                                                    {
                                                        selected_playlist.musicNormalOrder();
                                                    }
                                                    else if(input3 != "terug")
                                                    {
                                                        Console.WriteLine("Type ja , nee of terug.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n");
                                                    ; Console.WriteLine("er staan geen nummers in de afspeellijst voeg eerst nummers toe.");
                                                    input3 = "terug";
                                                }
                                            }
                                        }
                                        else if (input2 == "maken")  // nieuwe speellijst maken
                                        {
                                            input3 = "";
                                            while (input3 != "terug")
                                            {
                                                Console.WriteLine("Type terug om geen afspeellijst te maken.");
                                                Console.WriteLine("Geef een naam voor de speellijst.");
                                                input3 = Console.ReadLine().ToLower();
                                                Console.WriteLine("\n");
                                                if (input3 != "terug")
                                                {
                                                    if (musicHolder.getSelectedPlaylist(input3) == null)
                                                    {
                                                        Playlist newList = new Playlist(input3);
                                                        musicHolder.createPlaylist(newList);
                                                        Console.WriteLine("Nieuwe speellijst is gemaakt.");
                                                        input3 = "terug";
                                                        Console.WriteLine("\n");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("afspeellijst naam bestaat al.");
                                                        Console.WriteLine("\n");
                                                    }
                                                }
                                                if(input3 == "terug")
                                                {
                                                    Console.WriteLine("Geen nieuwe afspeellijst is gemaakt");
                                                    Console.WriteLine("\n");
                                                }
                                            }
                                        }
                                        else if (input2 == "delete")    // afspeellijst verwijderen
                                        {
                                            musicHolder.deletePlaylist(selected_playlist);
                                            input2 = "terug";
                                            Console.WriteLine("afspeellijst is verwijderd.");
                                            Console.WriteLine("\n");
                                            if(musicHolder.getAllPlaylists().Count == 0)
                                            {
                                                input5 = "terug";
                                            }

                                        }
                                        else if (input2 != "terug")
                                        {
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Type terug , toevoegen , verwijderen , maken , afspelen of delete.");
                                        }
                                    }
                                }
                                else if(input5 != "terug")
                                {
                                    Console.WriteLine("speellijst bestaat niet.");
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                    else
                    {                       // persoon heeft nog  geen afspeellijst
                        Console.WriteLine("Wil je een nieuwe speellijst maken?");
                        Console.WriteLine("Type ja of nee");
                        input = Console.ReadLine().ToLower();
                        Console.WriteLine("\n");
                        if (input == "ja")
                        {
                            while (input != "terug")
                            {
                                Console.WriteLine("Geef een naam voor de speellijst.");
                                input = Console.ReadLine();
                                Console.WriteLine("\n");

                                if (input != null)
                                {
                                    Playlist newList = new Playlist(input);
                                    musicHolder.createPlaylist(newList);
                                    input = "terug";
                                }
                                else
                                {
                                    Console.WriteLine("Naam voor afspeellijst kan niet niks zijn.");
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Er is geen afspeellijst gemaakt.");
                            Console.WriteLine("\n");

                        }
                    }
                }
                else if (input == "zoeken")
                { // muziek zoeken
                            input2 = "";
                    while (input2 != "terug")
                    {
                        Console.WriteLine("Type terug om terug te gaan.");
                        Console.WriteLine("Type nummer om een nummer te zoeken.");
                        Console.WriteLine("Type album om een album te zoeken.");
                        input2 = Console.ReadLine().ToLower();
                        Console.WriteLine("\n");

                        if (input2 == "nummer") // een nummer zoeken
                        {
                            input3 = "";
                            while (input3 != "terug")
                            {
                                int x = 0;
                                Console.WriteLine("Type terug om terug te gaan");
                                Console.WriteLine("Zoek een nummer.");
                                input3 = Console.ReadLine();
                                if (input3 != null)
                                {

                                    Music selected_Song = alleMuziek.getSongName(input3);
                                    if (selected_Song != null)
                                    {

                                        Console.WriteLine("\n");
                                        if (x == 0)
                                        {
                                            Console.WriteLine(selected_Song.Name + " is gevonden.");
                                            Console.WriteLine("\n");
                                            x = 1;
                                        }
                                        input5 = "";
                                        while (input5 != "terug")
                                        {
                                            Console.WriteLine("Type terug om terug te gaan.");
                                            Console.WriteLine("type afspelen om het nummer af te spelen.");
                                            Console.WriteLine("type toevoegen om een nummer toe te voegen aan een afspeellijst.");
                                            input5 = Console.ReadLine().ToLower();
                                            Console.WriteLine("\n");

                                            if (input5 == "afspelen")   // nummer afspelen
                                            {
                                                selected_Song.playsong();
                                                Console.WriteLine("\n");

                                            }
                                            else if (input5 == "toevoegen") // nummer toevoegen aan afspeellijst
                                            {
                                                musicHolder.readList();
                                                Console.WriteLine("\n");

                                                Console.WriteLine("Kies een afspeellijst.");
                                                input5 = Console.ReadLine().ToLower();
                                                Console.WriteLine("\n");
                                                if (musicHolder.getPlaylistName(input5) == true)
                                                {
                                                    Playlist selected_playlist = musicHolder.getSelectedPlaylist(input5);
                                                    Music songIsInPlaylist = selected_playlist.getSongName(input5);
                                                    if (input5 == "terug")
                                                    {

                                                    }
                                                    else if (songIsInPlaylist != null)
                                                    {
                                                        Console.WriteLine("nummer staat al in afspeellijst.");
                                                        Console.WriteLine("\n");

                                                    }
                                                    else if (selected_Song != null && songIsInPlaylist == null)
                                                    {
                                                        selected_playlist.addsong(selected_Song);
                                                        Console.WriteLine("Nummer is toegevoegd aan afspeellijst.");
                                                        Console.WriteLine("\n");

                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Nummer bestaat niet.");

                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("de gekozen afspeellijst bestaat niet.");
                                                    Console.WriteLine("\n");
                                                }
                                            }
                                            else if (input5 != "terug")
                                            {
                                                Console.WriteLine("Type toevoegen , afspelen of terug.");
                                                Console.WriteLine("\n");
                                            }
                                        }
                                    }
                                    else if (input3 != "terug")
                                    {
                                        Console.WriteLine("Nummer bestaat niet.");
                                        Console.WriteLine("\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("kan geen lege waardes zoeken.");
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                        else if (input2 == "album")  // album zoeken
                        {
                            input4 = "";
                            while (input4 != "terug")
                            {
                                int x = 0;

                                Console.WriteLine("Type terug om terug te gaan");
                                Console.WriteLine("Zoek een album.");
                                input4 = Console.ReadLine().ToLower();
                                Console.WriteLine("\n");
                                if (input4 != null)
                                {
                                    Album selected_Album = allAlbums.getAlbumName(input4);
                                    if (selected_Album != null)
                                    {
                                        if (x == 0)
                                        {
                                            Console.WriteLine(selected_Album.Name + " is gevonden.");
                                            Console.WriteLine("\n");
                                            x = 1;
                                        }
                                        input5 = "";
                                        while (input5 != "terug")
                                        {
                                            Console.WriteLine("Type terug om terug te gaan");
                                            Console.WriteLine("type afspelen om het album af te spelen.");
                                            Console.WriteLine("type toevoegen om een album toe te voegen aan een afspeellijst.");
                                            input5 = Console.ReadLine().ToLower();
                                            Console.WriteLine("\n");
                                            if (input5 == "afspelen")
                                            {                           // album afspelen
                                                input3 = "";
                                                while (input3 != "terug")
                                                {
                                                    Console.WriteLine("Type terug om terug te gaan.");
                                                    Console.WriteLine("Type ja om de muziek op normale volgorde af te spelen.");
                                                    Console.WriteLine("Type nee om de muziek op random volgorde af te spelen.");
                                                    input3 = Console.ReadLine().ToLower();
                                                    Console.WriteLine("\n");

                                                    if (input3 == "ja")
                                                    {                       // normale volgorde afspelen
                                                        selected_Album.playAlbum();
                                                        Console.WriteLine("\n");
                                                    }
                                                    else if (input3 == "nee")
                                                    {                   // random volgorde afspelen
                                                        selected_Album.albumRandomOrder();
                                                        Console.WriteLine("\n");
                                                    }
                                                    else if (input3 != "terug")
                                                    {                   // terug gaan
                                                        Console.WriteLine("Kies tussen ja , nee of terug.");
                                                        Console.WriteLine("\n");
                                                    }
                                                }


                                            }
                                            else if (input5 == "toevoegen")
                                            {       //album toevoegen aan afspeellijst
                                                musicHolder.readList();
                                                Console.WriteLine("Kies een afspeellijst.");
                                                input5 = Console.ReadLine().ToLower();
                                                Console.WriteLine("\n");
                                                if (musicHolder.getPlaylistName(input5) == true)
                                                {
                                                    Playlist selected_playlist = musicHolder.getSelectedPlaylist(input5);
                                                    if (selected_Album != null)
                                                    {
                                                        selected_playlist.addAlbumToPlaylist(selected_Album);
                                                        Console.WriteLine("Album is toegevoegd.");
                                                        Console.WriteLine("\n");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Album bestaat niet.");
                                                        Console.WriteLine("\n");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("de gekozen afspeellijst bestaat niet.");
                                                    Console.WriteLine("\n");
                                                }
                                            }
                                            else if (input5 != "terug")
                                            {
                                                Console.WriteLine("Kies tussen toevoegen of afspelen.");
                                                Console.WriteLine("\n");
                                            }
                                        }
                                    }
                                    else if (input4 != "terug")
                                    {
                                        Console.WriteLine("Album bestaat niet.");
                                        Console.WriteLine("\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("kan geen lege waardes zoeken.");
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                        else if (input2 != "terug")
                        {
                            Console.WriteLine("Type terug , nummer of album.");
                            Console.WriteLine("\n");

                        }
                    }
                }
                else if(input == "vriendenlijst")
                {   // vriendenlijst inkijken
                    while (input != "terug")
                    {
                        Console.WriteLine("Type terug om terug te gaan.");
                        Console.WriteLine("Type zoeken om te zoeken naar vrienden.");
                        Console.WriteLine("Type vrienden om je vriendenlijst in te zien.");
                        Console.WriteLine("Type verzoeken om je vriend verzoeken in te zien.");
                        input = Console.ReadLine().ToLower();
                        Console.WriteLine("\n");
                        if (input == "verzoeken")
                        {       // vrienden verzoeken inzien
                            input2 = "";
                            while (input2 != "terug")
                            {
                                friendlist.vriendVerzoeken();
                                Console.WriteLine("Type een naam om toe te voegen of verwijderen.");
                                Console.WriteLine("Type terug om terug te gaan.");
                                input2 = Console.ReadLine().ToLower();
                                Console.WriteLine("\n");
                                if (input2 != null)
                                {
                                    if (name.Friendslist.getVerzoek(input2) != null)
                                    {
                                        Person selectedPerson = allePersonen.searchFriends(input2);
                                        Console.WriteLine("\n");

                                        input3 = "";
                                        while (input3 != "terug")
                                        {
                                            Console.WriteLine("type terug om terug te gaan.");
                                            Console.WriteLine("Type verwijderen om de persoon te weigeren.");
                                            Console.WriteLine("Type toevoegen om de persoon toe te voegen aan je vriendenlijst.");
                                            input3 = Console.ReadLine().ToLower();
                                            Console.WriteLine("\n");

                                            if (input3 == "verwijderen")
                                            {                           // verzoek wijgeren
                                                friendlist.verwijderVerzoeken(selectedPerson);
                                                Console.WriteLine("Verzoek is verwijderd.");
                                                Console.WriteLine("\n");
                                                input3 = "terug";

                                            }
                                            else if (input3 == "toevoegen")
                                            {                           // verzoek acccepteren
                                                friendlist.verwijderVerzoeken(selectedPerson);
                                                friendlist.addFriend(selectedPerson);
                                                Console.WriteLine("Vriend is toegevoegd aan vriendenlijst.");
                                                Console.WriteLine("\n");
                                                input3 = "terug";
                                            }
                                            else if (input3 != "terug")
                                            {
                                                Console.WriteLine("Kies verwijderen , toevoegen of terug.");
                                                Console.WriteLine("\n");
                                            }
                                        }
                                    }
                                    else if(input2 != "terug")
                                    {
                                        Console.WriteLine("Persoon heeft geen verzoek gestuurd.");
                                        Console.WriteLine("\n");
                                    }
                                }
                                else if (input2 != "terug")
                                {
                                    Console.WriteLine("Kies een persoon of kies om terug te gaan.");
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                        else if (input == "vrienden")
                        {       // vriendenlijst inzien
                            input2 = "";
                            while (input2 != "terug")
                            {
                                name.Friendslist.vriendenLijst();
                                Console.WriteLine("Type terug om terug te gaan.");
                                Console.WriteLine("Selecteer een vriend.");
                                input2 = Console.ReadLine().ToLower();
                                Console.WriteLine("\n");

                                if (input2 != "terug")
                                {
                                    Person selectedPerson = friendlist.searchFriends(input2);
                                    Console.WriteLine("\n");


                                    string person = input2;
                                    if (selectedPerson != null && input2 != "terug")
                                    {
                                        input3 = "";
                                        while (input3 != "terug")
                                        {
                                            Console.WriteLine("Type terug om terug te gaan.");
                                            Console.WriteLine("Type speellijst om zijn speellijsten in te zien.");
                                            Console.WriteLine("Type verwijderen om de vriend te verwijderen.");
                                            input3 = Console.ReadLine().ToLower();
                                            Console.WriteLine("\n");
                                            if (input3 == "verwijderen")
                                            {                           // vriend verwijderen uit vriendenlijst
                                                Console.WriteLine("Weet je zeker dat je deze vriend wilt verwijderen?");
                                                Console.WriteLine("Type Ja om de vriend te verwijderen.");
                                                Console.WriteLine("Type nee om de vriend te houden.");
                                                input3 = Console.ReadLine().ToLower();
                                                Console.WriteLine("\n");
                                                if (input3 == "ja")
                                                {
                                                    friendlist.removeFriend(person);
                                                    input3 = "terug";
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Vriend is niet verwijderd.");
                                                    Console.WriteLine("\n");
                                                }
                                            }
                                            else if (input3 == "speellijst")
                                            {                           // afspeellijst van vrienden inzien
                                                input4 = "";
                                                while (input4 != "terug")
                                                {
                                                    Console.WriteLine("Type terug om terug te gaan.");
                                                    Console.WriteLine("Type inzien om de afspeellijsten in te zien.");
                                                    Console.WriteLine("Type afspelen om de afspeellijst af te spelen.");
                                                    Console.WriteLine("Type kopieren om de afspeellijst te kopiëren.");

                                                    input4 = Console.ReadLine().ToLower();
                                                    Console.WriteLine("\n");
                                                    if (input4 == "inzien")
                                                    {
                                                        input5 = "";
                                                        while (input5 != "terug")
                                                        { 
                                                            selectedPerson.Playlistlibraries.readList();
                                                            Console.WriteLine("\n");
                                                            Console.WriteLine("Type terug om terug te gaan.");
                                                            Console.WriteLine("Type welke afspeellijst je wil inzien.");
                                                            input5 = Console.ReadLine().ToLower();
                                                            Console.WriteLine("\n");

                                                            if (selectedPerson.Playlistlibraries.getPlaylistName(input5) != false)
                                                            {
                                                             Playlist selected = selectedPerson.Playlistlibraries.getSelectedPlaylist(input5);
                                                                foreach (Music song in selected.Songlist)
                                                                {
                                                                    Console.WriteLine(song.Name);
                                                                }
                                                                Console.WriteLine("Einde van afspeellijst");
                                                                Console.WriteLine("\n");
                                                            }
                                                        }
                                                    }
                                                    else if (input4 == "afspelen")
                                                    {                       // muziek afspelen
                                                        input5 = "";
                                                        while (input5 != "terug")
                                                        {
                                                            selectedPerson.Playlistlibraries.readList();
                                                            Console.WriteLine("\n");

                                                            Console.WriteLine("Type terug om terug te gaan.");
                                                            Console.WriteLine("Kies een afspeellijst.");
                                                            input5 = Console.ReadLine().ToLower();
                                                            Library selectedLibrary = selectedPerson.Playlistlibraries;
                                                            Playlist selectedPlaylist = selectedLibrary.getSelectedPlaylist(input5);
                                                            Console.WriteLine("\n");
                                                            if (selectedPlaylist != null)
                                                            {
                                                                input6 = "";
                                                                while (input6 != "terug")
                                                                {
                                                                    Console.WriteLine("Type terug om terug te gaan.");
                                                                    Console.WriteLine("Klik op spatie om de muziek te pauzeren.");
                                                                    Console.WriteLine("Wil je de afspeellijst in random volgorde afspelen?.");
                                                                    Console.WriteLine("Type ja voor random volgorde.");
                                                                    Console.WriteLine("type nee om de standaard volgorde af te spelen.");
                                                                    input6 = Console.ReadLine().ToLower();
                                                                    Console.WriteLine("\n");
                                                                    if (input6 == "ja")
                                                                    {                   // muziek afspelen in random volgorde
                                                                        selectedPlaylist.musicRandomOrder();
                                                                        Console.WriteLine("\n");
                                                                    }
                                                                    else if (input6 == "nee")
                                                                    {                   // muziek in normale volgorde afspelen
                                                                        selectedPlaylist.musicNormalOrder();
                                                                        Console.WriteLine("\n");
                                                                    }
                                                                    else if (input6 != "terug")
                                                                    {
                                                                        Console.WriteLine("Type ja ,nee of terug.");
                                                                        Console.WriteLine("\n");
                                                                    }
                                                                }
                                                            }
                                                            else if (input5 != "terug")
                                                            {
                                                                Console.WriteLine("Deze afspeellijst bestaat niet.");
                                                                Console.WriteLine("\n");
                                                            }
                                                        }
                                                    }
                                                    else if (input4 == "kopieren")
                                                    {                               // afspeellijst kopieren
                                                        selectedPerson.Playlistlibraries.readList();
                                                        Console.WriteLine("Kies een afspeellijst.");
                                                        input4 = Console.ReadLine().ToLower();
                                                        Library selectedLibrary = selectedPerson.Playlistlibraries;
                                                        Playlist selectedPlaylist = selectedLibrary.getSelectedPlaylist(input4);
                                                        Console.WriteLine("\n");

                                                        if (selectedPlaylist != null)
                                                        {
                                                            string temp = input4;

                                                            Console.WriteLine("Geef een naam voor de afspeellijst.");
                                                            input4 = Console.ReadLine();
                                                            Console.WriteLine("\n");
                                                            if (input4 != null)
                                                            {
                                                                if (musicHolder.getSelectedPlaylist(input4) == null)
                                                                {
                                                                    //selectedPlaylist.Playlistname = input4;
                                                                    Playlist newplaylist = new Playlist(input4);
                                                                    foreach(Music Song in selectedPlaylist.Songlist)
                                                                    {
                                                                        newplaylist.Songlist.Add(Song);
                                                                    }
                                                                    musicHolder.createPlaylist(newplaylist);

                                                                    Console.WriteLine("afspeellijst is gekopiëerd.");
                                                                    Console.WriteLine("\n");
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("De afspeellijst naam bestaat al.");
                                                                    Console.WriteLine("\n");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Kan geen lege waarde zoeken.");
                                                                Console.WriteLine("\n");
                                                            }

                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Deze afspeellijst bestaat niet.");
                                                            Console.WriteLine("\n");
                                                        }

                                                    }
                                                    else if (input4 != "terug")
                                                    {
                                                        Console.WriteLine("Kies tussen kopieren ,afspelen , inzien of terug.");
                                                        Console.WriteLine("\n");
                                                    }
                                                }
                                            }
                                            else if (input3 != "terug")
                                            {
                                                Console.WriteLine("Kies tussen speellijst ,verwijderen of terug.");
                                                Console.WriteLine("\n");

                                            }
                                        }
                                    }
                                    else if(input2 != "terug")
                                    {
                                        Console.WriteLine("Persoon is niet bevriend met jou.");
                                        Console.WriteLine("\n");

                                    }
                                }
                                else if (input2 != "terug")
                                {
                                    Console.WriteLine("De gekozen persoon staat niet in je vrienden lijst.");
                                    Console.WriteLine("\n");
                                }
                            }
                        }

                        else if (input == "zoeken")
                        {
                            input2 = "";
                            while (input2 != "terug")
                            {
                                Console.WriteLine("Type terug om terug te gaan.");
                                Console.WriteLine("Zoek een persoon op.");
                                input2 = Console.ReadLine().ToLower();
                                Console.WriteLine("\n");
                                if (input2 != null)
                                {                   // personen zoeken
                                    Person selectedPerson = allePersonen.searchFriends(input2);
                                    if (selectedPerson != null)
                                    {
                                        Console.WriteLine("Wil je een vriendschapsverzoek versturen?");
                                        Console.WriteLine("Type ja om een verzoek te sturen.");
                                        Console.WriteLine("Type nee om geen verzoek te sturen.");
                                        input2 = Console.ReadLine().ToLower();
                                        Console.WriteLine("\n");
                                        if (input2 == "ja")
                                        {                   // vriendschapsverzoek sturen
                                            Friendlist selectedFriendlist = selectedPerson.Friendslist;
                                            selectedFriendlist.stuurVerzoek(name);
                                            Console.WriteLine("Verzoek is gestuurd.");
                                            Console.WriteLine("\n");
                                        }
                                        else if(input2 != "terug")
                                        {
                                            Console.WriteLine("Verzoek is niet gestuurd.");
                                            Console.WriteLine("\n");
                                        }
                                    }
                                    else if (input2 != "terug")
                                    {
                                        Console.WriteLine("Persoon is niet gevonden.");
                                        Console.WriteLine("\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Er kunnen geen lege waardes gezocht worden.");
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                        else if(input != "terug")
                        {
                            Console.WriteLine("Kies vrienden , zoeken , verzoeken of terug.");
                            Console.WriteLine("\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Type speellijst ,zoeken , vriendenlijst of stop.");
                    Console.WriteLine("\n");
                }
            }
        }
    }
}