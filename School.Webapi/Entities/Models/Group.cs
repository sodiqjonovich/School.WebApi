using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Webapi.Entities.Models
{
    public class Group:BaseEntity
    {
        public string ClassName { get; set; }

        public int Pupils { get; set; }
    }
}
