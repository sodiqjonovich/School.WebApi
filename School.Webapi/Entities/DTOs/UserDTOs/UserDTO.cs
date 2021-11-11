namespace School.Webapi.Entities.DTOs.UserDTOs
{
    public class UserDTO : LoginDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
