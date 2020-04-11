using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }

        public LoginViewModel() { }

        public LoginViewModel(string un, string pw, string mail)
        {
            Username = un;
            Password = pw;
            Email = mail; 
        }
    }
}