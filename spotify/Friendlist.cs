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
        public void removeFriend(string input)
        {
            int found = 0;
            foreach (var item in this.friends)
            {
                if (item.Name == input)
                {
                    friends.Remove(item);
                    Console.WriteLine("Vriend is verwijderd");
                    Console.WriteLine("Vriend is verwijderd");
                    found++;
                } 

            }
            if (found == 0)
            {
                Console.WriteLine("Persoon staat niet in je vriendenlijst");
            }

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
