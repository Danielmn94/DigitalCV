using AutoMapper;
using DigitalCV.Data.Domain.Models;
using DigitalCV.DTO.DTOs;
using DigitalCV.Web.Models.ViewModels.Admin;
using DigitalCV.Web.Models.ViewModels.Certificate;
using DigitalCV.Web.Models.ViewModels.ComputerTechnology;
using DigitalCV.Web.Models.ViewModels.Education;
using DigitalCV.Web.Models.ViewModels.Identity;
using DigitalCV.Web.Models.ViewModels.Language;
using DigitalCV.Web.Models.ViewModels.WorkExperience;
using System.Globalization;

namespace DigitalCV.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginViewModel, LoginDTO>();

            //Education
            CreateMap<Education, EducationDTO>();
            CreateMap<EducationDTO, Education>();
            CreateMap<EducationDTO, EducationViewModel>();
            CreateMap<EducationViewModel, EducationDTO>();

            CreateMap<WorkExperience, WorkExperienceDTO>();
            CreateMap<WorkExperienceDTO, WorkExperienceViewModel>()
            .AfterMap((workexpdto, workexpvm) => workexpvm.KeyAreasSplitted = workexpdto.KeyAreas.Split(','));
            CreateMap<WorkExperienceDTO, WorkExperience>();
            CreateMap<AdminWorkExperienceViewModel, WorkExperienceDTO>();
            CreateMap<WorkExperienceDTO, AdminWorkExperienceViewModel>();

            CreateMap<ComputerTechnology, ComputerTechnologyDTO>();
            CreateMap<ComputerTechnologyDTO, ComputerTechnologyViewModel>()
            .AfterMap((comptechdto, comtechvm) => comtechvm.ITSkillsSplitted = comptechdto.ITSkills.Split(','));
            CreateMap<ComputerTechnologyDTO, AdminComputerTechnologyViewModel>();
            CreateMap<AdminComputerTechnologyViewModel, ComputerTechnologyDTO>();
            CreateMap<ComputerTechnologyDTO, ComputerTechnology>();

            CreateMap<LanguageViewModel, LanguageDTO>();
            CreateMap<LanguageDTO, LanguageViewModel>();
            CreateMap<LanguageDTO, Language>();
            CreateMap<Language, LanguageDTO>();

            CreateMap<Certificate, CertificateDTO>();
            CreateMap<CertificateViewModel, CertificateDTO>();
            CreateMap<CertificateDTO, CertificateViewModel>();
            CreateMap<CertificateDTO, Certificate>();

            CreateMap<RegisterViewModel, RegisterDTO>();
        }
    }
}
