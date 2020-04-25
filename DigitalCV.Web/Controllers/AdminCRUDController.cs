using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalCV.DTO.DTOs;
using DigitalCV.Service.Interfaces;
using DigitalCV.Web.Models.ViewModels.Admin;
using DigitalCV.Web.Models.ViewModels.Certificate;
using DigitalCV.Web.Models.ViewModels.Education;
using DigitalCV.Web.Models.ViewModels.Language;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCV.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminCRUDController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEducationService _educationService;
        private readonly IWorkExperienceService _workExperienceService;
        private readonly IComputerTechnologyService _computerTechnologyService;
        private readonly ILangaugeService _langaugeService;
        private readonly ICertificateService _certificateService;

        public AdminCRUDController(IMapper mapper, IEducationService educationService, IWorkExperienceService workExperienceService,
            IComputerTechnologyService computerTechnologyService, ILangaugeService langaugeService, ICertificateService certificateService)
        {
            _mapper = mapper;
            _educationService = educationService;
            _workExperienceService = workExperienceService;
            _computerTechnologyService = computerTechnologyService;
            _langaugeService = langaugeService;
            _certificateService = certificateService;
        }

        #region Education
        [HttpGet]
        public IActionResult CreateUpdateEducation(EducationViewModel model)
        {
            ViewBag.ShowNavbar = false;

            //Create
            if (model.Id != 0)
            {
                var education = _educationService.GetEducationFromID(model.Id);

                var convertedModel = _mapper.Map<EducationViewModel>(education);

                convertedModel.AspAction = "UpdateEducation";
                convertedModel.AspController = "AdminCRUD";
                convertedModel.ButttonText = "Opdater";

                return View("CreateUpdateEducation", convertedModel);
            }

            model.AspAction = "CreateEducation";
            model.AspController = "AdminCRUD";
            model.ButttonText = "Opret";

            return View("CreateUpdateEducation", model);
        }

        [HttpPost]
        public IActionResult CreateEducation(EducationViewModel model)
        {
            ViewBag.ShowNavbar = false;

            var convertedModel = _mapper.Map<EducationDTO>(model);

            _educationService.CreateEducation(convertedModel);

            return RedirectToAction("Education", "Admin");
        }

        [HttpPost]
        public IActionResult UpdateEducation(EducationViewModel model)
        {
            var convertedModel = _mapper.Map<EducationDTO>(model);

            _educationService.UpdateEducation(convertedModel);

            return RedirectToAction("Education", "Admin");
        }

        public IActionResult DeleteEducation(EducationViewModel model)
        {
            _educationService.DeleteEducation(model.Id);

            return RedirectToAction("Education", "Admin");
        }
        #endregion

        #region WorkExperience
        [HttpGet]
        public IActionResult CreateUpdateWorkExperience(AdminWorkExperienceViewModel model)
        {
            ViewBag.ShowNavbar = false;

            //Create
            if (model.Id != 0)
            {
                var workExperience = _workExperienceService.GetWorkExperienceFromID(model.Id);

                var convertedModel = _mapper.Map<AdminWorkExperienceViewModel>(workExperience);

                convertedModel.AspAction = "UpdateWorkExperience";
                convertedModel.AspController = "AdminCRUD";
                convertedModel.ButttonText = "Opdater";

                return View("CreateUpdateWorkExperience", convertedModel);
            }

            model.AspAction = "CreateWorkExperience";
            model.AspController = "AdminCRUD";
            model.ButttonText = "Opret";

            return View("CreateUpdateWorkExperience", model);
        }

        [HttpPost]
        public IActionResult UpdateWorkExperience(AdminWorkExperienceViewModel model)
        {
            var convertedModel = _mapper.Map<WorkExperienceDTO>(model);

            _workExperienceService.UpdateWorkExperience(convertedModel);

            return RedirectToAction("WorkExperience", "Admin");
        }

        [HttpPost]
        public IActionResult CreateWorkExperience(AdminWorkExperienceViewModel model)
        {
            var convertedModel = _mapper.Map<WorkExperienceDTO>(model);

            _workExperienceService.CreateWorkExperience(convertedModel);

            return RedirectToAction("WorkExperience", "Admin");
        }

        public IActionResult DeleteWorkExperience(AdminWorkExperienceViewModel model)
        {
            _workExperienceService.DeleteWorkExperience(model.Id);

            return RedirectToAction("WorkExperience", "Admin");
        }
        #endregion

        #region ComputerTechnology
        [HttpGet]
        public IActionResult CreateUpdateComputerTechnology(AdminComputerTechnologyViewModel model)
        {
            ViewBag.ShowNavbar = false;

            //Create
            if (model.Id != 0)
            {
                var computerTechnology = _computerTechnologyService.GetComputerTechnologyFromID(model.Id);

                var convertedModel = _mapper.Map<AdminComputerTechnologyViewModel>(computerTechnology);

                convertedModel.AspAction = "UpdateComputerTechnology";
                convertedModel.AspController = "AdminCRUD";
                convertedModel.ButttonText = "Opdater";

                return View("CreateUpdateComputerTechnology", convertedModel);
            }

            model.AspAction = "CreateComputerTechnology";
            model.AspController = "AdminCRUD";
            model.ButttonText = "Opret";

            return View("CreateUpdateComputerTechnology", model);
        }

        [HttpPost]
        public IActionResult CreateComputerTechnology(AdminComputerTechnologyViewModel model)
        {
            ViewBag.ShowNavbar = false;

            var convertedModel = _mapper.Map<ComputerTechnologyDTO>(model);

            _computerTechnologyService.CreateComputerTechnology(convertedModel);

            return RedirectToAction("ComputerTechnology","Admin");
        }

        [HttpPost]
        public IActionResult UpdateComputerTechnology(AdminComputerTechnologyViewModel model)
        {
            var convertedModel = _mapper.Map<ComputerTechnologyDTO>(model);

            _computerTechnologyService.UpdateComputerTechnology(convertedModel);

            return RedirectToAction("ComputerTechnology", "Admin");
        }

        public IActionResult DeleteComputerTechnology(AdminComputerTechnologyViewModel model)
        {
            _computerTechnologyService.DeleteComputerTechnology(model.Id);

            return RedirectToAction("ComputerTechnology", "Admin");
        }
        #endregion

        [HttpGet]
        public IActionResult CreateUpdateLanguage(LanguageViewModel model)
        {
            ViewBag.ShowNavbar = false;

            //Create
            if (model.Id != 0)
            {
                var langauge = _langaugeService.GetLanguageFromID(model.Id);

                var convertedModel = _mapper.Map<LanguageViewModel>(langauge);

                convertedModel.AspAction = "UpdateLanguage";
                convertedModel.AspController = "AdminCRUD";
                convertedModel.ButttonText = "Opdater";

                return View("CreateUpdateLanguage", convertedModel);
            }

            model.AspAction = "CreateLanguage";
            model.AspController = "AdminCRUD";
            model.ButttonText = "Opret";

            return View("CreateUpdateLanguage", model);
        }

        [HttpPost]
        public IActionResult CreateLanguage(LanguageViewModel model)
        {
            ViewBag.ShowNavbar = false;

            var convertedModel = _mapper.Map<LanguageDTO>(model);

            _langaugeService.CreateLanguage(convertedModel);

            return RedirectToAction("MiscellaneousInfo", "Admin");
        }

        [HttpPost]
        public IActionResult UpdateLanguage(LanguageViewModel model)
        {
            var convertedModel = _mapper.Map<LanguageDTO>(model);

            _langaugeService.UpdateLanguage(convertedModel);

            return RedirectToAction("MiscellaneousInfo", "Admin");
        }

        public IActionResult DeleteLanguage(LanguageViewModel model)
        {
            _langaugeService.DeleteLanguage(model.Id);

            return RedirectToAction("MiscellaneousInfo", "Admin");
        }

        [HttpGet]
        public IActionResult CreateUpdateCertificate(CertificateViewModel model)
        {
            ViewBag.ShowNavbar = false;

            //Create
            if (model.Id != 0)
            {
                var certificate = _certificateService.GetCertificateFromID(model.Id);

                var convertedModel = _mapper.Map<CertificateViewModel>(certificate);

                convertedModel.AspAction = "UpdateCertificate";
                convertedModel.AspController = "AdminCRUD";
                convertedModel.ButttonText = "Opdater";

                return View("CreateUpdateCertificate", convertedModel);
            }

            model.AspAction = "CreateCertificate";
            model.AspController = "AdminCRUD";
            model.ButttonText = "Opret";

            return View("CreateUpdateCertificate", model);
        }

        [HttpPost]
        public IActionResult CreateCertificate(CertificateViewModel model)
        {
            ViewBag.ShowNavbar = false;

            var convertedModel = _mapper.Map<CertificateDTO>(model);

            _certificateService.CreateCertificate(convertedModel);

            return RedirectToAction("MiscellaneousInfo", "Admin");
        }

        [HttpPost]
        public IActionResult UpdateCertificate(CertificateViewModel model)
        {
            var convertedModel = _mapper.Map<CertificateDTO>(model);

            _certificateService.UpdateCertificate(convertedModel);

            return RedirectToAction("MiscellaneousInfo", "Admin");
        }

        public IActionResult DeleteCertificate(CertificateViewModel model)
        {
            _certificateService.DeleteCertificate(model.Id);

            return RedirectToAction("MiscellaneousInfo", "Admin");
        }

    }
}