using System.ComponentModel.DataAnnotations;

namespace School.Webapi.Entities.DTOs
{
    public abstract class PersonDTO
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string Definition { get; set; }

        public string Image { get; set; }
    }
}
