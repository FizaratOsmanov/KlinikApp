using AutoMapper;
using BL.DTOs;
using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Profiles
{
    public class DepartmentProfiles : Profile
    {
        public DepartmentProfiles()
        {
            CreateMap<DepartmentGetDTO, Department>().ReverseMap();
            CreateMap<DepartmentPutDTO, Department>().ReverseMap();
            CreateMap<DepartmentPostDTO, Department>().ReverseMap();
            CreateMap<DepartmentGetDTO, DepartmentPutDTO>().ReverseMap();
        }
    }
}
