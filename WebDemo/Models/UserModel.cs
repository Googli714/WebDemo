using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class UserModel
    {
        public int Id { get; set; }        
        public string UserId { get; set; }
        [Display(Name = "მომხმარებელი")]
        public string UserName { get; set; }
        [Display(Name = "პაროლი")]
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}