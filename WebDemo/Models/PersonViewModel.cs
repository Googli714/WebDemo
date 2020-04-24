using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace WebDemo.Models
{
    public class PersonViewModel
    {
        public PersonViewModel() { persons = new List<PersonModel>(); }
        public List<PersonModel> persons { get; set; }
        public PersonModel FilterPerson { get; set; }
        public IEnumerable<SelectListItem> genderlist { get; set; }
    }

    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public bool? Gender { get; set; }
        public int Id { get; set; }

        public PersonModel() { }

        public PersonModel(int id, string fn, string ln, bool g, string pp)
        {
            Id = id;
            FirstName = fn;
            LastName = ln;
            Gender = g;
            Username = pp;
        }
    }
}