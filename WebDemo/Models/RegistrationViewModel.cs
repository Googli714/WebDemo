using System.ComponentModel.DataAnnotations;

namespace WebDemo.Models
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int RoleId { get; set; }

        public RegistrationViewModel()
        {
        }

        public RegistrationViewModel(string un, string pw, string email, string f, string l, bool g, int roleid)
        {
            Username = un;
            Password = pw;
            Email = email;
            FirstName = f;
            LastName = l;
            Gender = g;
            RoleId = roleid;
        }
    }
}