using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnetmvcapp.Models
{
    public class Register
    {
        [Required]
        [Display(Name= "UserName")]
        public string UserName { get; set; }
         [Required]
         [EmailAddress]
         [Display(Name="Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name="ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage="The Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name="PhoneNumber")]
        [RegularExpression(@"^\+?(\d{1,4})?[-.]?(\d{1,14})$",ErrorMessage="Invalid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public int UserRole { get; set; }        
    }
}