using AutoMapper;
using School.Webapi.Entities.DTOs;
using School.Webapi.Entities.Models;

namespace School.Webapi.Mapping
{
    public class MappingConfigure:Profile
    {
        public MappingConfigure()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<New, NewDTO>().ReverseMap();
            CreateMap<Pupil, PupilDTO>().ReverseMap();
            CreateMap<Information, InformationDTO>().ReverseMap();
        }
    }
}
