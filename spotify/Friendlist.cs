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
        private List<Person> Verzoeken = new List<Person>();

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
                    found++;
                } 

            }
            if (found == 0)
            {
                Console.WriteLine("Persoon staat niet in je vriendenlijst");
            }

        }

        public Person searchFriends(string input)
        {
            foreach(var item in this.friends)
            {
                if (item.Name == input)
                {
                    Console.WriteLine("Vriend is gevonden");
                    return item;
                }
            }
            Console.WriteLine("Persoon is niet gevonden");
            return null;
        }
        public void vriendVerzoeken()
        {
            foreach(var item in this.Verzoeken)
            {
                Console.Write(item.Name);
            }
        }

        public void verwijderVerzoeken(Person person)
        {
            foreach (var item in this.Verzoeken)
            {
                if(person == item) 
                {
                    Verzoeken.Remove(item);
                }
            }
        }

        public void stuurVerzoek(Person person)
        {
            Verzoeken.Add(person);
        }

    }


}
