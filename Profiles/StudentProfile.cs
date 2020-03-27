using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enitities;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>().ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => $"{src.FirstName}{src.LastName}")).ForMember(dest => dest.GenderDisplay, opt => opt.MapFrom(src => src.Gender.ToString()));

            CreateMap<StudentAddDto, Student>();
        }
    }
}
