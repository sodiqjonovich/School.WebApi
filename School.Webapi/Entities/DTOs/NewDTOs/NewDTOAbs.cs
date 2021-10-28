using System;
using System.ComponentModel.DataAnnotations;

namespace School.Webapi.Entities.DTOs.NewDTOs
{
    public abstract class NewDTOAbs
    {
        [Required]
        [MaxLength(70)]
        public string Title { get; set; }

        public DateTime Date { get; set; }
    }
}
