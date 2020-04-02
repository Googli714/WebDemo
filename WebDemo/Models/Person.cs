using System.ComponentModel.DataAnnotations;

namespace WebDemo.Models
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public bool Gender { get; set; }

        public Person()
        {
        }

        public Person(string f, string l, bool g)
        {
            FirstName = f;
            LastName = l;
            Gender = g;
        }
    }
}