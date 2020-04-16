using AutoMapper;
using DigitalCV.Service.Interfaces;
using DigitalCV.Web.Models.ViewModels.Education;
using DigitalCV.Web.Models.ViewModels.WorkExperience;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DigitalCV.Web.Controllers
{

    public class DashboardController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IWorkExperienceService _workExperienceService;
        private readonly IMapper _mapper;

        public DashboardController(IEducationService educationService, IWorkExperienceService workExperienceService ,IMapper mapper)
        {
            _educationService = educationService;
            _workExperienceService = workExperienceService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Education()
        {
            var educations = _educationService.GetEducations();

            var convertedEducations = _mapper.Map<List<EducationViewModel>>(educations);

            return View(convertedEducations);
        }

        [HttpGet]
        public IActionResult WorkExperience()
        {
            var viewmodel = new WorkExperienceViewModel();

            var workExperiences = _workExperienceService.GetWorkExperiences();

            var convertedWorkExperiences = _mapper.Map<List<WorkExperienceViewModel>>(workExperiences);

            return View(convertedWorkExperiences);
        }

        [HttpGet]
        public IActionResult ITExperience()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MiscellaneousInfo()
        {
            return View();
        }
    }
}
