using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class PersonViewModel
    {
        public List<PersonModel> persons { get; set; }
    }

    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public bool Gender { get; set; }
        public int Id { get; set; }

        public PersonModel() { }

        public PersonModel(string fn, string ln, bool g, string pp)
        {
            FirstName = fn;
            LastName = ln;
            Gender = g;
            Username = pp;
        }
    }
}