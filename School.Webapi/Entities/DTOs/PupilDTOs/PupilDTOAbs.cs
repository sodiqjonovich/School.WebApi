using System.ComponentModel.DataAnnotations;

namespace School.Webapi.Entities.DTOs.PupilDTOs
{
    public abstract class PupilDTOAbs
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public int Degree { get; set; }
    }
}
