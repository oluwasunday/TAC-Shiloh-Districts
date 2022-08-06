using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TACShilohDistricts.Core.DTOs;
using TACShilohDistricts.Core.Entities;

namespace TACShilohDistricts.Application.Mapper
{
    public class AutoMapperIntializer : Profile
    {
        public AutoMapperIntializer()
        {
            CreateMap<ContactUs, ContactUsDto>().ReverseMap();
        }
    }
}
