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
        }
    }
}
