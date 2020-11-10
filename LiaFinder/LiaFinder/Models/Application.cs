using System;
using System.Collections.Generic;
using System.Text;

namespace LiaFinder.Models
{
    public class Application
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
    }
}
