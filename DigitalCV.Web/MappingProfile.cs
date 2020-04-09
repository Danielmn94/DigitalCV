using AutoMapper;
using DigitalCV.DTO.DTOs;
using DigitalCV.Web.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginViewModel, LoginDTO>();
        }
    }
}
