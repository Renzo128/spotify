using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using playlistlibrary;
using friendlist;
namespace person
{
    public class Person
    {
        private string name;
        private PlaylistLibrary playlistlibrary;
        private Friendlist friendlist;
            public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Friendlist Friendslist { 
            get { return friendlist; } 
            set { friendlist = value; }
        }
        public PlaylistLibrary Playlistlibraries
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
