using System;
using System.Collections.Generic;
using System.Text;

namespace LiaFinder.Tables
{
   public class CompanyTable
    {
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanySubject { get; set; }
        public string CompanyLocation { get; set; }
        public int CompanyinternSpots { get; set; }


    }
}
