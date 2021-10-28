using Microsoft.AspNetCore.Http;

namespace School.Webapi.Entities.DTOs.PupilDTOs
{
    public class PupilDTOCreated : PupilDTOAbs
    {
        public string Definition { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
