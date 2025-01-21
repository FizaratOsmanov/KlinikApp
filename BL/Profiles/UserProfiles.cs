using AutoMapper;
using BL.DTOs;
using Microsoft.AspNetCore.Identity;

namespace BL.Profiles
{
    public  class UserProfiles:Profile
    {
        public UserProfiles()
        {
            CreateMap<LoginDTO,IdentityUser>().ReverseMap();
            CreateMap<RegisterDTO,IdentityUser>().ReverseMap();
        }
    }
}
