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
            public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Friendlist friendlist { 
            get { return friendlist; } 
            set { friendlist = value; }
        }
        private PlaylistLibrary playlistlibrary
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
