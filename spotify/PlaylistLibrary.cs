using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using playlist;
using person;
namespace playlistlibrary
{
    public class PlaylistLibrary
    {
        private List <Playlist> library = new List<Playlist>();
        private int amountOfPlaylist;
        private Person name;

        public PlaylistLibrary(Person person)
        {
            this.name = person;
        }
        public PlaylistLibrary(Playlist playlist, Person person)
        {
            library.Add(playlist);
            this.amountOfPlaylist++;
            this.name = person;
        }
        public List<Playlist> getAllPlaylists()
        {
            return library;
        }
        public void playPlaylist(Playlist playlist)
        {

        }
        public bool getPlaylistName(string input)
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
        public void deletePlaylist(Playlist playlist)
        {
            this.library.Remove(playlist);
            Console.WriteLine("Playlist is removed.");
        }
        public void createPlaylist(Playlist playlist)
        {
            this.library.Add(playlist);
            Console.WriteLine("Playlist is added");
            this.amountOfPlaylist++;

        }

        public void readList()
        {
            foreach (var item in this.library)
            {
                Console.WriteLine(item.Playlistname);
            }
        }
        public Playlist getSelectedPlaylist(string input)
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


    }
}
