using AutoMapper;
using DigitalCV.Service.Interfaces;
using DigitalCV.Web.Models.ViewModels.ComputerTechnology;
using DigitalCV.Web.Models.ViewModels.WorkExperience;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DigitalCV.Web.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IComputerTechnologyService _computerTechnologyService;
        private readonly IWorkExperienceService _workExperienceService;

        public DashboardController(IEducationService educationService, IWorkExperienceService workExperienceService, 
            IComputerTechnologyService computerTechnologyService, ILangaugeService miscellaneousInfoService, IMapper mapper, ICertificateService certificateService) 
            : base(educationService,miscellaneousInfoService, mapper, certificateService)
        {
            _mapper = mapper;
            _computerTechnologyService = computerTechnologyService;
            _workExperienceService = workExperienceService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Education()
        {
            return View(GetEducations());
        }

        [HttpGet]
        public IActionResult WorkExperience()
        {
            var workExperiences = _workExperienceService.GetWorkExperiences();

            var convertedWorkExperiences = _mapper.Map<List<WorkExperienceViewModel>>(workExperiences);

            return View(convertedWorkExperiences);
        }

        [HttpGet]
        public IActionResult ComputerTechnology()
        {
            var computerTechnologies = _computerTechnologyService.GetComputerTechnologies();

            var convertedComputerTechnologies = _mapper.Map<List<ComputerTechnologyViewModel>>(computerTechnologies);

            return View(convertedComputerTechnologies);
        }

        [HttpGet]
        public IActionResult MiscellaneousInfo()
        {
            return View(GetMiscellaneousInfo());
        }
    }
}
