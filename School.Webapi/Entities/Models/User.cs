using Microsoft.AspNetCore.Identity;

namespace School.Webapi.Entities.Models
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
