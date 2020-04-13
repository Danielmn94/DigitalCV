using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Web.Controllers
{

    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Education()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WorkExperience()
        {
            return View();
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
