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
            this.amountOfPlaylist = this.amountOfPlaylist + 1;
            this.name = person;
        }
        public void getAllPlaylists()
        {

        }
        public void playPlaylist(Playlist playlist)
        {

        }
        public void getPlaylistName()
        {

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
        }
    }
}
