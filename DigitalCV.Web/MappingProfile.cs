using AutoMapper;
using DigitalCV.Data.Domain.Models;
using DigitalCV.DTO.DTOs;
using DigitalCV.Web.Models.ViewModels.Account;
using DigitalCV.Web.Models.ViewModels.ComputerTechnology;
using DigitalCV.Web.Models.ViewModels.Education;
using DigitalCV.Web.Models.ViewModels.WorkExperience;
using System.Globalization;

namespace DigitalCV.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginViewModel, LoginDTO>();
            CreateMap<Education, EducationDTO>();
            CreateMap<EducationDTO, EducationViewModel>();
            CreateMap<WorkExperience, WorkExperienceDTO>()
                .AfterMap((workexp, workexpdto) => workexpdto.KeyAreasSplitted = workexp.KeyAreas.Split(','));
            CreateMap<WorkExperienceDTO, WorkExperienceViewModel>();
            CreateMap<ComputerTechnology, ComputerTechnologyDTO>()
                .AfterMap((comptech, comtechdto) => comtechdto.ITSkillsSplitted = comptech.ITSkills.Split(','));
            CreateMap<ComputerTechnologyDTO, ComputerTechnologyViewModel>();
            CreateMap<Language, LanguageDTO>()
                .AfterMap((lang, langdto) => langdto.Language = new CultureInfo(lang.LanguageCode).DisplayName);
            CreateMap<Certificate, CertificateDTO>();
        }
    }
}
