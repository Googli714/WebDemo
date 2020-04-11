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
        public bool Gender { get; set; }

        public PersonModel() { }

        public PersonModel(string fn, string ln, bool g)
        {
            FirstName = fn;
            LastName = ln;
            Gender = g;
        }
    }
}