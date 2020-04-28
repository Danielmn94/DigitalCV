using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using DigitalCV.DTO.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using DigitalCV.Data.Helpers;
using Microsoft.AspNetCore.Http;

namespace DigitalCV.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Logger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountRepository(SignInManager<ApplicationUser> signInManager, Logger logger, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<SignInResult> LoginPassword(LoginDTO model)
        {
            try
            {
                return await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
            }
            catch (Exception e)
            {
                _logger.LogError(GetType().Name, "Username: " + model.Username + " RememberMe: " + model.RememberMe, e.Message,
                    e.InnerException == null ? "" : e.InnerException.Message);

                return null;
            }
        }

        public async Task Login(ApplicationUser user)
        {
            try
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            catch (Exception e)
            {
                _logger.LogError(GetType().Name, "Username: " + user.UserName, e.Message,
                    e.InnerException == null ? "" : e.InnerException.Message);
            }
        }

        public async void LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception e)
            {
                _logger.LogErrorWithUser(GetType().Name, "No model", e.Message,  e.InnerException == null ? "" : e.InnerException.Message,
                    _httpContextAccessor.HttpContext.User.Identity.Name);
            }
        }
    }
}
