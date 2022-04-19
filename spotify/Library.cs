using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using playlist;
using person;
using album;
namespace library
{
    public class Library
    {
        private List <Playlist> library = new List<Playlist>();
        private List<Album> albums = new List<Album>();
        private int amountOfPlaylist;
        private Person name;

        public Library(Person person)   // object maken
        {
            this.name = person;
        }
        public Library(Playlist playlist, Person person)
        {
            library.Add(playlist);
            this.amountOfPlaylist++;
            this.name = person;
        }
        public List<Playlist> getAllPlaylists() // alle playlists ophalen
        {
            return library;
        }
        public bool getPlaylistName(string input)   // playlist ophalen
        {
            foreach (var item in this.library)
            {
                if(item.Playlistname == input)
                {
                    return true;
                }

            }
            return false;
        }
        public void deletePlaylist(Playlist playlist)   // playlist verwijderen
        {
            this.library.Remove(playlist);
        }
        public void createPlaylist(Playlist playlist)   // playlist toevoegen aan playlists
        {
            this.library.Add(playlist);
            this.amountOfPlaylist++;

        }

        public void readList()  // alle playlist namen displayen
        {
            foreach (var item in this.library)
            {

                Console.WriteLine(item.Playlistname);
            }
        }
        public Playlist getSelectedPlaylist(string input)   // playlist selecteren
        {
            foreach (var item in this.library)
            {
                if (item.Playlistname == input)
                {
                    return item;
                }

            }
            return null;
        }

        public Album getAlbumName(string input) // album selecteren
        {

            foreach (var item in this.albums)
            {
                if (item.Name == input)
                {
                    return item;
                }

            }
            return null;
        }

        public void readListAlbum() // alle albums displayen
        {
            foreach (var item in this.albums)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void addAlbum(Album album)   // album toevoegen aan album list
        {
            albums.Add(album);
        }
    }
}
