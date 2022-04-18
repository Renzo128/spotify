using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library;
using friendlist;
namespace person
{
    public class Person
    {
        private string name;
        private Library playlistlibrary;
        private Friendlist friendlist;
            public string Name  // getter setters voor person
        {
            get { return name; }
            set { name = value; }
        }
        public Friendlist Friendslist { 
            get { return friendlist; } 
            set { friendlist = value; }
        }
        public Library Playlistlibraries
        {
            get {  return playlistlibrary; }
            set {playlistlibrary = value; }
    }
        public Person(string name)
        {
            this.name = name;
        }

    }
}
