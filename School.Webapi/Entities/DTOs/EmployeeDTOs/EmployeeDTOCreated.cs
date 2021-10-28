using Microsoft.AspNetCore.Http;

namespace School.Webapi.Entities.DTOs.EmployeeDTOs
{
    public class EmployeeDTOCreated : EmployeeDTOAbs
    {
        public string Definition { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
