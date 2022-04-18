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


            while (input != "stop" )    // begin programma
            {
                input2 = "";
                Console.WriteLine("type speellijst om naar playlist te gaan");
                Console.WriteLine("type zoeken om muziek te zoeken te gaan");
                Console.WriteLine("type vriendenlijst om naar vriendenlijst te gaan");
                Console.WriteLine("type stop om te stoppen");

                input = Console.ReadLine().ToLower();
                Console.WriteLine("\n");
                if(input == "speellijst")   // speellijsten maken updaten verwijderen
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
                                        if (input2 == "toevoegen")  // muziek toevoegen aan afspeellijst
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
                                                    else
                                                    {
                                                        Console.WriteLine("Er kunnen geen lege waardes gezocht worden");
                                                    }
                                                }
                                                else if (input3 == "album")
                                                {
                                                    allAlbums.readListAlbum();
                                                    Console.WriteLine("Kies een album om toe te voegen");
                                                    Console.WriteLine("Type terug om terug te gaan");

                                                    input4 = Console.ReadLine().ToLower();
                                                    if (input4 != null)
                                                    {
                                                        Album selected_album = allAlbums.getAlbumName(input4);
                                                        if (selected_album != null)
                                                        {
                                                            selected_playlist.addAlbumToPlaylist(selected_album);
                                                            Console.WriteLine("Album is toegevoegd");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Album bestaat niet.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Er kunnen geen lege waardes gezocht worden.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Kies tussen album of nummer om muziek toe te voegen");
                                                }
                                            }
                                        }
                                        else if (input2 == "verwijderen")   // muziek verwijderen uit afspeellijst
                                        {
                                            input3 = "";
                                            while (input3 != "terug")
                                            {
                                                Console.WriteLine("\n");
                                                selected_playlist.readList();
                                                Console.WriteLine("Kies een nummer om te verwijderen");
                                                Console.WriteLine("Type terug om terug te gaan");
                                                input3 = Console.ReadLine().ToLower();

                                                Console.WriteLine("\n");
                                                if (input3 == "terug")
                                                {

                                                }
                                                else if (input3 != null)
                                                {
                                                    Music selected_Song = alleMuziek.getSongName(input3);
                                                    if (selected_Song != null)
                                                    {
                                                        selected_playlist.removeSong(selected_Song);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Nummer heeft niet in afspeellijst gestaan");

                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Er kunnen geen lege waardes gezocht worden");
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
                                        else if (input2 == "speellijst maken")  // nieuwe speellijst maken
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
                                                    Console.WriteLine("Nieuwe speellijst is gemaakt.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("afspeellijst naam bestaat al.");
                                                }
                                            }
                                        }
                                        else if (input2 == "delete")    // afspeellijst verwijderen
                                        {
                                            musicHolder.deletePlaylist(selected_playlist);
                                            input2 = "terug";
                                            Console.WriteLine("\n");
                                            Console.WriteLine("afspeellijst is verwijderd.");
                                            Console.WriteLine("\n");

                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("speellijst bestaat niet.");
                                }
                            }
                        }
                    }
                    else
                    {                       // persoon heeft nog  geen afspeellijst
                        Console.WriteLine("Wil je een nieuwe speellijst maken?");
                        Console.WriteLine("ja / nee");
                        input = Console.ReadLine().ToLower();
                        if (input == "ja")
                        {
                            while (input != "terug")
                            {
                                Console.WriteLine("Geef een naam voor de speellijst.");
                                input = Console.ReadLine();
                                if (input != null)
                                {
                                    Playlist newList = new Playlist(input);
                                    musicHolder.createPlaylist(newList);
                                    input = "terug";
                                }
                                else
                                {
                                    Console.WriteLine("Naam voor afspeellijst kan niet niks zijn.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Er is geen afspeellijst gemaakt.");
                        }
                    }
                }
                else if (input == "zoeken")
                { // muziek zoeken
                    while (input != "terug")
                    {
                        Console.WriteLine("type terug om terug te gaan.");
                        Console.WriteLine("type zoeken om te zoeken.");

                        input = Console.ReadLine().ToLower();
                        if (input == "zoeken")
                        {
                            input2 = "";
                            while (input2 != "terug")
                            {
                                Console.WriteLine("Type terug om terug te gaan.");
                                Console.WriteLine("Type nummer om een nummer te zoeken.");
                                Console.WriteLine("Type album om een album te zoeken.");
                                input2 = Console.ReadLine();
                                if (input2 == "nummer") // een nummer zoeken
                                {
                                    Console.WriteLine("Zoek een nummer");

                                    input2 = Console.ReadLine();

                                    if (input2 != null)
                                    {
                                        Music selected_Song = alleMuziek.getSongName(input2);
                                        if (selected_Song != null)
                                        {
                                            Console.WriteLine(selected_Song.Name + " is gevonden");
                                            Console.WriteLine("type afspelen om het nummer af te spelen");
                                            Console.WriteLine("type toevoegen om een nummer toe te voegen aan een afspeellijst");
                                            input = Console.ReadLine().ToLower();
                                            if (input2 == "afspelen")   // nummer afspelen
                                            {
                                                selected_Song.playsong();
                                            }
                                            else if (input2 == "toevoegen") // nummer toevoegen aan afspeellijst
                                            {

                                                musicHolder.readList();

                                                Console.WriteLine("Kies een afspeellijst.");
                                                input = Console.ReadLine().ToLower();
                                                if (musicHolder.getPlaylistName(input2) == true)
                                                {
                                                    Playlist selected_playlist = musicHolder.getSelectedPlaylist(input2);
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
                                    else
                                    {
                                        Console.WriteLine("\n");
                                        Console.WriteLine("kan geen lege waardes zoeken.");
                                        Console.WriteLine("\n");
                                    }
                                }
                                else if(input2 == "album")  // album zoeken
                                {
                                    Console.WriteLine("Zoek een album");

                                    input2 = Console.ReadLine();

                                    if (input2 != null)
                                    {
                                        Album selected_Album = allAlbums.getAlbumName(input2);
                                        if (selected_Album != null)
                                        {                           
                                            Console.WriteLine(selected_Album.Name + " is gevonden");
                                            Console.WriteLine("type afspelen om het nummer af te spelen");
                                            Console.WriteLine("type toevoegen om een nummer toe te voegen aan een afspeellijst");
                                            input = Console.ReadLine().ToLower();
                                            if (input2 == "afspelen")
                                            {                           // album afspelen
                                                input3 = "";
                                                while(input3 != "terug")
                                                {
                                                    Console.WriteLine("Type ja om de muziek op normale volgorde af te spelen.");
                                                    Console.WriteLine("Type nee om de muziek op random volgorde af te spelen.");
                                                    Console.WriteLine("Type terug om terug te gaan.");
                                                    input3 = Console.ReadLine().ToLower();
                                                    if(input3 == "ja")
                                                    {                       // normale volgorde afspelen
                                                        selected_Album.playAlbum();
                                                    }
                                                    else if(input3 == "nee")
                                                    {                   // random volgorde afspelen
                                                        selected_Album.albumRandomOrder();
                                                    }
                                                    else if(input3 != "terug")
                                                    {                   // terug gaan
                                                        Console.WriteLine("Kies tussen ja , nee of terug.");
                                                    }
                                                }


                                            }
                                            else if (input2 == "toevoegen")
                                            {       //album toevoegen aan afspeellijst

                                                musicHolder.readList();

                                                Console.WriteLine("Kies een afspeellijst.");
                                                input = Console.ReadLine().ToLower();
                                                if (musicHolder.getPlaylistName(input2) == true)
                                                {
                                                    Playlist selected_playlist = musicHolder.getSelectedPlaylist(input2);
                                                    if (selected_Album != null)
                                                    {
                                                        selected_playlist.addAlbumToPlaylist(selected_Album);
                                                        Console.WriteLine("Album is toegevoegd.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Album bestaat niet.");
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
                                    else
                                    {
                                        Console.WriteLine("\n");
                                        Console.WriteLine("kan geen lege waardes zoeken.");
                                        Console.WriteLine("\n");
                                    }
                                }
                            }
                        }
                        else if (input != "terug")
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
                        Console.WriteLine("Type terug om terug te gaan.");
                        Console.WriteLine("Type zoeken om te zoeken naar vrienden.");
                        Console.WriteLine("Type vrienden om je vriendenlijst in te zien.");
                        Console.WriteLine("Type verzoeken om je vriend verzoeken in te zien.");
                        input = Console.ReadLine().ToLower();
                        if (input == "verzoeken")
                        {       // vrienden verzoeken inzien
                            input2 = "";
                            while (input2 != "terug")
                            {
                                friendlist.vriendVerzoeken();
                                Console.WriteLine("Type een naam om toe te voegen of verwijderen");
                                Console.WriteLine("Type terug om terug te gaan.");
                                input2 = Console.ReadLine().ToLower();
                                if (input2 != null)
                                {
                                    Person selectedPerson = allePersonen.searchFriends(input2);
                                    Console.WriteLine("Type verwijderen om de persoon te weigeren");
                                    Console.WriteLine("Type toevoegen om de persoon toe te voegen aan je vriendenlijst");
                                    Console.WriteLine("type terug om terug te gaan");
                                    input2 = Console.ReadLine().ToLower();

                                    if (input2 == "verwijderen")
                                    {                           // verzoek wijgeren
                                        friendlist.verwijderVerzoeken(selectedPerson);
                                        Console.WriteLine("Verzoek is verwijderd");

                                    }
                                    else if (input2 == "toevoegen")
                                    {                           // verzoek acccepteren
                                        friendlist.verwijderVerzoeken(selectedPerson);
                                        friendlist.addFriend(selectedPerson);
                                        Console.WriteLine("Vriend is toegevoegd aan vriendenlijst");
                                    }
                                    else if (input2 != "terug")
                                    {
                                        Console.WriteLine("Kies verwijderen , toevoegen of terug");
                                    }
                                }
                                else if (input2 != "terug")
                                {
                                    Console.WriteLine("Kies een persoon of kies om terug te gaan.");
                                }
                            }
                        }
                        else if (input == "vrienden")
                        {       // vriendenlijst inzien
                            while (input2 != "terug")
                            {
                                Console.WriteLine("Selecteer een vriend.");
                                Console.WriteLine("Type terug om terug te gaan.");
                                Person selectedPerson = friendlist.searchFriends(input2);
                                input2 = Console.ReadLine().ToLower();
                                string person = input2;
                                if (selectedPerson != null && input2 != "terug")
                                {
                                    input3 = "";
                                    while (input3 != "terug")
                                    {
                                        Console.WriteLine("Type terug om terug te gaan");
                                        Console.WriteLine("Type speellijst om zijn speellijsten in te zien");
                                        Console.WriteLine("Type verwijderen om de vriend te verwijderen");
                                        input3 = Console.ReadLine().ToLower();
                                        if (input3 == "verwijderen")
                                        {                           // vriend verwijderen uit vriendenlijst
                                            Console.WriteLine("Weet je zeker dat je deze vriend wilt verwijderen?");
                                            Console.WriteLine("Type Ja om de vriend te verwijderen.");
                                            Console.WriteLine("Type nee om de vriend te houden.");
                                            input3 = Console.ReadLine().ToLower();
                                            if (input3 == "ja")
                                            {
                                                friendlist.removeFriend(person);
                                                input3 = "terug";
                                            }
                                            else
                                            {
                                                Console.WriteLine("Vriend is niet verwijderd");
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

                                                if (input4 == "inzien")
                                                {
                                                    Console.WriteLine(selectedPerson.Playlistlibraries);
                                                }
                                                else if (input4 == "afspelen")
                                                {                       // muziek afspelen
                                                    while (input5 != "terug")
                                                    {
                                                        Console.WriteLine(selectedPerson.Playlistlibraries);
                                                        Console.WriteLine("Type terug om terug te gaan");
                                                        Console.WriteLine("Kies een afspeellijst");
                                                        input5 = Console.ReadLine().ToLower();
                                                        Library selectedLibrary = selectedPerson.Playlistlibraries;
                                                        Playlist selectedPlaylist = selectedLibrary.getSelectedPlaylist(input5);
                                                        if (selectedPlaylist != null)
                                                        {
                                                            input6 = "";
                                                            while (input6 != "terug")
                                                            {

                                                                int i = 0;
                                                                int j = 0;
                                                                Console.WriteLine("Type terug om terug te gaan");
                                                                Console.WriteLine("Klik op spatie om de muziek te pauzeren");
                                                                Console.WriteLine("Wil je de afspeellijst in random volgorde afspelen?");
                                                                Console.WriteLine("Type ja voor random volgorde");
                                                                Console.WriteLine("type nee om de standaard volgorde af te spelen");
                                                                input6 = Console.ReadLine().ToLower();
                                                                if (input6 == "ja")
                                                                {                   // muziek afspelen in random volgorde
                                                                    selectedPlaylist.musicRandomOrder(i, j);
                                                                }
                                                                else if (input6 == "nee")
                                                                {                   // muziek in normale volgorde afspelen
                                                                    selectedPlaylist.musicNormalOrder(i, j);
                                                                }
                                                                else if (input6 != "terug")
                                                                {
                                                                    Console.WriteLine("Type ja ,nee of terug");
                                                                }
                                                            }
                                                        }
                                                        else if (input5 != "terug")
                                                        {
                                                            Console.WriteLine("Deze afspeellijst bestaat niet.");
                                                        }
                                                    }
                                                }
                                                else if (input4 == "kopieren")
                                                {                               // afspeellijst kopieren
                                                    Console.WriteLine(selectedPerson.Playlistlibraries);
                                                    Console.WriteLine("Kies een afspeellijst");
                                                    input4 = Console.ReadLine().ToLower();
                                                    Library selectedLibrary = selectedPerson.Playlistlibraries;
                                                    Playlist selectedPlaylist = selectedLibrary.getSelectedPlaylist(input2);
                                                    if (selectedPlaylist != null)
                                                    {
                                                        musicHolder.createPlaylist(selectedPlaylist);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Deze afspeellijst bestaat niet.");
                                                    }
                                                }
                                                else if (input4 != "terug")
                                                {
                                                    Console.WriteLine("Kies tussen kopieren ,afspelen of terug.");
                                                }
                                            }
                                        }
                                        else if (input3 != "terug")
                                        {
                                            Console.WriteLine("Kies tussen speellijst ,verwijderen of terug.");

                                        }
                                    }
                                }
                                else if (input != "terug")
                                {
                                    Console.WriteLine("De gekozen persoon staat niet in je vrienden lijst.");
                                }
                            }
                        }



                        else if (input == "zoeken")
                        {
                            while (input != "terug")
                            {
                                Console.WriteLine("Type terug om terug te gaan.");
                                Console.WriteLine("Zoek een persoon op.");
                                input = Console.ReadLine().ToLower();
                                if (input != null)
                                {                   // personen zoeken
                                    Person selectedPerson = allePersonen.searchFriends(input);
                                    if (selectedPerson != null)
                                    {
                                        Console.WriteLine("Wil je een vriendschapsverzoek versturen?");
                                        Console.WriteLine("Type ja om een verzoek te sturen");
                                        Console.WriteLine("Type nee om geen verzoek te sturen");
                                        input = Console.ReadLine().ToLower();
                                        if (input == "ja")
                                        {                   // vriendschapsverzoek sturen
                                            Friendlist selectedFriendlist = selectedPerson.Friendslist;
                                            selectedFriendlist.addFriend(name);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Verzoek is niet gestuurd");
                                        }
                                    }
                                    else if (input != "terug")
                                    {
                                        Console.WriteLine("Persoon is niet gevonden");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Er kunnen geen lege waardes gezocht worden.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Kies vrienden , zoeken of verzoeken.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Type speellijst ,zoeken of vriendenlijst.");
                }
            }
        }
    }
}