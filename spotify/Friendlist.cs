using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person;
using playlist;
namespace friendlist
{
    public class Friendlist
    {
        private List<Person> friends = new List<Person>();

        public Friendlist()
        {

        }
        public void addFriend(Person person)
        {
            friends.Add(person);    
        }
        public void removeFriend(Person person)
        {
            friends.Remove(person);
        }

        public void searchFriends(Person person)
        {

        }

        public void viewPlaylistOfFriends(Person person)
        {

        }
        public void copyPlaylist(Playlist playlist)
        {

        }

    }


}
