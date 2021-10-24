using System.ComponentModel.DataAnnotations;

namespace School.Webapi.Entities.Models
{
    public abstract class Person:BaseEntity
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string Definition { get; set; }

        public string Image { get; set; }
    }
}
