using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Enitities;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class ClassRoomProfile:Profile
    {
        public ClassRoomProfile()
        {
            CreateMap<ClassRoom, ClassRoomDto>().ForMember(dest=>dest.ClassName,opt=>opt.MapFrom(src=>src.Name));
        }
    }
}
