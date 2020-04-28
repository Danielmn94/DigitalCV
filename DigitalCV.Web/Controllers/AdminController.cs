using System.Collections.Generic;   
using AutoMapper;
using DigitalCV.DTO.DTOs;
using DigitalCV.Service.Interfaces;
using DigitalCV.Web.Models.ViewModels.Admin;
using DigitalCV.Web.Models.ViewModels.Education;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCV.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : BaseController
    {
        private readonly IComputerTechnologyService _computerTechnologyService;
        private readonly IWorkExperienceService _workExperienceService;
        private readonly IEducationService _educationService;
        private readonly IMapper _mapper;

        public AdminController(IEducationService educationService, ICertificateService certificateService, IComputerTechnologyService computerTechnologyService, IWorkExperienceService workExperienceService, ILangaugeService langaugeService, IMapper mapper)
            : base(educationService, langaugeService, mapper, certificateService)
        {
            _computerTechnologyService = computerTechnologyService;
            _workExperienceService = workExperienceService;
            _mapper = mapper;
            _educationService = educationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ShowNavbar = false;

            return View();
        }

        [HttpGet]
        public IActionResult Education()
        {
            ViewBag.ShowNavbar = false;

            return View(GetEducations());
        }

        [HttpGet]
        public IActionResult WorkExperience()
        {
            ViewBag.ShowNavbar = false;

            var workExperiences = _workExperienceService.GetWorkExperiences();

            var convertedWorkExperiences = _mapper.Map<List<AdminWorkExperienceViewModel>>(workExperiences);

            return View(convertedWorkExperiences);
        }

        [HttpGet]
        public IActionResult ComputerTechnology()
        {
            ViewBag.ShowNavbar = false;

            var computerTechnologies = _computerTechnologyService.GetComputerTechnologies();

            var convertedComputerTechnologies = _mapper.Map<List<AdminComputerTechnologyViewModel>>(computerTechnologies);

            return View(convertedComputerTechnologies);
        }

        [HttpGet]
        public IActionResult MiscellaneousInfo()
        {
            ViewBag.ShowNavbar = false;

            return View(GetMiscellaneousInfo());
        }

    }
}