using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapiapp.Models
{
    public class User : BaseEntity
    {
        public User(){

        }
        public User(Register model){
            UserName = model.UserName;
            UserRole = model.UserRole;
            Email = model.Email;
            PhoneNumber = model.PhoneNumber;
        }
        
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Role UserRole { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}