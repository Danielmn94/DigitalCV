using System.Threading.Tasks;
using AutoMapper;
using DigitalCV.DTO.DTOs;
using DigitalCV.Service.Interfaces;
using DigitalCV.Web.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCV.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper, IAccountService accountService)
        {
            _userService = userService;
            _mapper = mapper;
            _accountService = accountService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByEmail(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Mail findes ikke");
                    return View(model);
                }

                var password = await _userService.CheckPassword(user, model.Password);

                if (!password)
                {
                    ModelState.AddModelError(string.Empty, "Password er forkert");
                    return View(model);
                }

                var convertedModel = _mapper.Map<LoginDTO>(model);

                var result = await _accountService.Login(convertedModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login fejlede");
                    return View(model);
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}