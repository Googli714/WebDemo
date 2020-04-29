namespace WebDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users_Table
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public int PersonId { get; set; }

        public int? RoleId { get; set; }

        public virtual Person_Table Person_Table { get; set; }

        public virtual Role Role { get; set; }
    }
}
