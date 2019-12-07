using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TestWebApp.Domain.AppObj;

namespace TestWebApp.Domain.Entities
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Index("IX_Name",1,IsUnique =true)]
        public string FirsName { get; set; }
        [Required]
        [Index("IX_Name", 2, IsUnique = true)]
        public string LastName { get; set; }
        [Required]
        public int Sex { get; set; }
        [Required]
        public string SaltedPassword { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime RegisteredDate { get; set; } = DateTime.Now;

    }
}