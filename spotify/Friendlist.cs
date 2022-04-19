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
        public void addFriend(Person person)    // persoon toevoegen aan friends list
        {
            friends.Add(person);    
        }
        public string removeFriend(string input)  // persoon verwijderen uit friends list
        {
            int found = 0;
            foreach (var item in this.friends)
            {
                if (item.Name == input)
                {
                    friends.Remove(item);   // vriend is verwijderd uit friends list
                    Console.WriteLine("Vriend is verwijderd");
                    found++;
                    return null;
                } 

            }
            if (found == 0)
            {   
                Console.WriteLine("Persoon staat niet in je vriendenlijst");    // vriend is niet gevonden
                return null;

            }
            return null;


        }

        public Person searchFriends(string input) // zoeken of persoon bestaat
        {
            foreach(var item in this.friends)  
            {
                if (item.Name == input)
                {
                    Console.WriteLine("Persoon is gevonden.");    // persoon bestaat
                    return item;
                }
            }  // persoon bestaat niet
            return null;
        }
        public void vriendVerzoeken()   // alle vriendverzoeken inzien
        {
            foreach(var item in this.Verzoeken)
            {
                Console.Write(item.Name);
                Console.WriteLine("\n");
            }
        }

        public void vriendenLijst()   // alle vriendverzoeken inzien
        {
            foreach (var item in this.friends)
            {
                Console.Write(item.Name);
                Console.WriteLine("\n");
            }
        }

        public string verwijderVerzoeken(Person person)   // vriendverzoeken afwijzen
        {
            foreach (var item in this.Verzoeken)
            {
                if(person == item) 
                {
                    Verzoeken.Remove(item);
                    return null;
                }
            }
            return null;
        }

        public void stuurVerzoek(Person person) // vriend verzoek sturen
        {
            Verzoeken.Add(person);
        }

        public Person getVerzoek(string input)
        {
            foreach (var item in this.Verzoeken)
            {
                if (input == item.Name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
