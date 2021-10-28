using System.ComponentModel.DataAnnotations;

namespace School.Webapi.Entities.DTOs.EmployeeDTOs
{
    public abstract class EmployeeDTOAbs
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string PhoneNumber { get; set; }

        public string Position { get; set; }
    }
}
