using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

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
        public int? RoleID { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }

        public RegistrationViewModel()
        {
            RoleList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Guest", Value = "2"},
                new SelectListItem { Text = "Editor", Value = "3"},
                new SelectListItem { Text = "Admin", Value = "1"}
            };
        }

        public RegistrationViewModel(string un, string pw, string email, string f, string l, bool g, int r)
        {
            Username = un;
            Password = pw;
            Email = email;
            FirstName = f;
            LastName = l;
            Gender = g;
            RoleID = r;
        }
    }
}