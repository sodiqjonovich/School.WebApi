using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Webapi.Entities.Models
{
    public class Employee:Person
    {
        public string PhoneNumber { get; set; }

        public string Position { get; set; }
    }
}
