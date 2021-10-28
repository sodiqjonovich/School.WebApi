using Microsoft.AspNetCore.Http;

namespace School.Webapi.Entities.DTOs.NewDTOs
{
    public class NewDTOCreated : NewDTOAbs
    {
        public IFormFile ImageFile { get; set; }

        public string Description { get; set; }
    }
}
