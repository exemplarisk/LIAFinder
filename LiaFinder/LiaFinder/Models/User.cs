using System;
using System.Collections.Generic;
using System.Text;
using LiaFinder.Tables;
using LiaFinder;

namespace LiaFinder.Shared.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User () { }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
      
    }
}
      
