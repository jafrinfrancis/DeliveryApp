using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapiapp.Models
{
    public class AuthResponse
    {
        public UserDetails UserDetails { get; set; }
        public string Token { get; set; }
    }
}