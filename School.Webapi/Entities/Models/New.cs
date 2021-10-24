using System;
using System.ComponentModel.DataAnnotations;

namespace School.Webapi.Entities.Models
{
    public class New:BaseEntity
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
