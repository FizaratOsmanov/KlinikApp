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
    public class DoctorProfiles:Profile
    {
        public DoctorProfiles()
        {
            CreateMap<DoctorGetDTO,Doctor>().ReverseMap();
            CreateMap<DoctorPutDTO,Doctor>().ReverseMap();
            CreateMap<DoctorPostDTO,Doctor>().ReverseMap();
        }
    }
}
