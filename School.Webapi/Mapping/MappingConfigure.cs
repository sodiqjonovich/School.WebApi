using AutoMapper;
using School.Webapi.Entities.DTOs;
using School.Webapi.Entities.DTOs.EmployeeDTOs;
using School.Webapi.Entities.DTOs.NewDTOs;
using School.Webapi.Entities.DTOs.PupilDTOs;
using School.Webapi.Entities.Models;

namespace School.Webapi.Mapping
{
    public class MappingConfigure:Profile
    {
        public MappingConfigure()
        {

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();

            // Pupil Model Mapping
            CreateMap<Pupil, PupilDTO>().ReverseMap();
            CreateMap<Pupil, PupilDTOCreated>().ReverseMap();
            CreateMap<Pupil, PupilDTOMain>().ReverseMap();

            // Employee Model Mapping
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTOMain>().ReverseMap();
            CreateMap<Employee, EmployeeDTOCreated>().ReverseMap();

            // New Model Mapping
            CreateMap<New, NewDTO>().ReverseMap();
            CreateMap<New, NewDTOCreated>().ReverseMap();
            CreateMap<New, NewDTOMain>().ReverseMap();
            CreateMap<New, NewDTOshort>().ReverseMap();

            CreateMap<Information, InformationDTO>().ReverseMap();
        }
    }
}
