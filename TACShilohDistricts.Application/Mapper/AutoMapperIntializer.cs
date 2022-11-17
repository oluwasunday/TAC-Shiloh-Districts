using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TACShilohDistricts.Core.DTOs;
using TACShilohDistricts.Core.DTOs.AppUserDtos;
using TACShilohDistricts.Core.DTOs.Gallery;
using TACShilohDistricts.Core.DTOs.Testimony;
using TACShilohDistricts.Core.Entities;

namespace TACShilohDistricts.Application.Mapper
{
    public class AutoMapperIntializer : Profile
    {
        public AutoMapperIntializer()
        {
            CreateMap<ContactUs, ContactUsDto>().ReverseMap();
            CreateMap<PrayerRequest, PrayerRequestDto>().ReverseMap();
            CreateMap<Gallery, GalleryDto>().ReverseMap();
            CreateMap<Testimony, TestimonyDto>().ReverseMap();

            // user related
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<UserDto, AppUser>().ReverseMap();
            CreateMap<AppUser, AddUserResponseDto>().ReverseMap();
            CreateMap<AddUserResponseDto, AppUser>().ReverseMap();
        }
    }
}
