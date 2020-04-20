using System.Threading.Tasks;
using AutoMapper;
using DigitalCV.DTO.DTOs;
using DigitalCV.Service.Interfaces;
using DigitalCV.Web.Models.ViewModels.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCV.Web.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public IdentityController(IUserService userService, IMapper mapper, IAccountService accountService)
        {
            _userService = userService;
            _mapper = mapper;
            _accountService = accountService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            ViewBag.ShowNavbar = false;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ViewBag.ShowNavbar = false;

            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByUsername(model.Username);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Brugernavn findes ikke");
                    return View(model);
                }

                var password = await _userService.CheckPassword(user, model.Password);

                if (!password)
                {
                    ModelState.AddModelError(string.Empty, "Password er forkert");
                    return View(model);
                }

                var convertedModel = _mapper.Map<LoginDTO>(model);

                var result = await _accountService.LoginPassword(convertedModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login fejlede");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Register()
        {
            ViewBag.ShowNavbar = false;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ViewBag.ShowNavbar = false;

            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByUsername(model.Username);

                if (user != null)
                {
                    ModelState.AddModelError(string.Empty, "Brugernavn er taget");
                    return View(model);
                }

                var applicationUser = _userService.CreateApplicationUser(model.Username);

                var result = _userService.CreateUser(applicationUser, model.Password);

                if (result.Result.Succeeded)
                {
                    await _accountService.Login(applicationUser);

                    return RedirectToAction("Index","Dashboard");
                }
                AddErrors(result.Result);
            }

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}