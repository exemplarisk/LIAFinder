﻿using System;
namespace LiaFinder.Tables
{
    // TODO Change to User
    // And implement changes
    public class User
    {
  
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public bool isCompany { get; set; } = false;

        public bool isLoggedIn { get; set; } = false;

        public Guid Id = Guid.NewGuid();

    }
}
