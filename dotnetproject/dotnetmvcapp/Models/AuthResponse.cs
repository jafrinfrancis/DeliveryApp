using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetmvcapp.Models
{
    public class AuthResponse
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}