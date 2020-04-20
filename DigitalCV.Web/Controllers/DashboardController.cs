using AutoMapper;
using DigitalCV.Service.Interfaces;
using DigitalCV.Web.Models.ViewModels.ComputerTechnology;
using DigitalCV.Web.Models.ViewModels.Education;
using DigitalCV.Web.Models.ViewModels.MiscellaneousInfo;
using DigitalCV.Web.Models.ViewModels.WorkExperience;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DigitalCV.Web.Controllers
{

    public class DashboardController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IWorkExperienceService _workExperienceService;
        private readonly IComputerTechnologyService _computerTechnologyService;
        private readonly IMiscellaneousInfoService _miscellaneousInfoService;
        private readonly IMapper _mapper;

        public DashboardController(IEducationService educationService, IWorkExperienceService workExperienceService, 
            IComputerTechnologyService computerTechnologyService, IMiscellaneousInfoService miscellaneousInfoService, IMapper mapper)
        {
            _educationService = educationService;
            _workExperienceService = workExperienceService;
            _computerTechnologyService = computerTechnologyService;
            _miscellaneousInfoService = miscellaneousInfoService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Education()
        {
            var educations = _educationService.GetEducations();

            var convertedEducations = _mapper.Map<List<EducationViewModel>>(educations);

            return View(convertedEducations);
        }

        [HttpGet]
        [Authorize]
        public IActionResult WorkExperience()
        {
            var workExperiences = _workExperienceService.GetWorkExperiences();

            var convertedWorkExperiences = _mapper.Map<List<WorkExperienceViewModel>>(workExperiences);

            return View(convertedWorkExperiences);
        }

        [HttpGet]
        [Authorize]
        public IActionResult ComputerTechnology()
        {
            var computerTechnologies = _computerTechnologyService.GetWorkExperiences();

            var convertedComputerTechnologies = _mapper.Map<List<ComputerTechnologyViewModel>>(computerTechnologies);

            return View(convertedComputerTechnologies);
        }

        [HttpGet]
        [Authorize]
        public IActionResult MiscellaneousInfo()
        {
            MiscellaneousInfoViewModel vm = new MiscellaneousInfoViewModel();

            vm.Certificates = _miscellaneousInfoService.GetCertificate();

            vm.Languages = _miscellaneousInfoService.GetLanguages();

            return View(vm);
        }
    }
}
