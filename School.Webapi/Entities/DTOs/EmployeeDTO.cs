namespace School.Webapi.Entities.DTOs
{
    public class EmployeeDTO : PersonDTO
    {
        public string PhoneNumber { get; set; }

        public string Position { get; set; }
    }
}
