using System.Collections.Generic;
using AutoMapper;
using DigitalCV.Service.Interfaces;
using DigitalCV.Web.Models.ViewModels.Education;
using DigitalCV.Web.Models.ViewModels.MiscellaneousInfo;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCV.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly ILangaugeService _langaugeService;
        private readonly ICertificateService _certificateService;
        private readonly IMapper _mapper;

        public BaseController(IEducationService educationService, ILangaugeService langaugeService, IMapper mapper, ICertificateService certificateService)
        {
            _educationService = educationService;
            _mapper = mapper;
            _langaugeService = langaugeService;
            _certificateService = certificateService;
        }

        public List<EducationViewModel> GetEducations()
        {
            var educations = _educationService.GetEducations();

            var convertedEducations = _mapper.Map<List<EducationViewModel>>(educations);

            return convertedEducations;
        }

        public MiscellaneousInfoViewModel GetMiscellaneousInfo()
        {
            MiscellaneousInfoViewModel vm = new MiscellaneousInfoViewModel();

            vm.Certificates = _certificateService.GetCertificates();

            vm.Languages = _langaugeService.GetLanguages();

            return vm;
        }
    }
}