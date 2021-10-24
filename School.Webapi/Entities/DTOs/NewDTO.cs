using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Webapi.Entities.DTOs
{
    public class NewDTO
    {
        [Required]
        [MaxLength(70)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Image { get; set; }
    }
}
