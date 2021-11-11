using System.ComponentModel.DataAnnotations;

namespace School.Webapi.Entities.DTOs.UserDTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
