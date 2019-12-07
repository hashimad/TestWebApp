using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestWebApp.Domain.AppObj;

namespace TestWebApp.ViewModel
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Password Mismatch")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string FirsName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public SEX Sex { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
  
    }
}