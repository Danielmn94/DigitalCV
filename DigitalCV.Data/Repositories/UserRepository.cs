using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using DigitalCV.Data.Helpers;

namespace DigitalCV.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Logger _logger;

        public UserRepository(UserManager<ApplicationUser> userManager, Logger logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<bool> CheckPassword(ApplicationUser user, string password)
        {
            try
            {
                return await _userManager.CheckPasswordAsync(user, password);
            }
            catch (Exception e)
            {
                _logger.LogError(GetType().Name, "Username: " + user.UserName, e.Message,
                    e.InnerException == null ? "" : e.InnerException.Message);

                return false;
            }
        }

        public ApplicationUser CreateApplicationUser(string username)
        {
            try
            {
                return new ApplicationUser { UserName = username };
            }
            catch (Exception e)
            {
                _logger.LogError(GetType().Name, "Username: " + username, e.Message,
                    e.InnerException == null ? "" : e.InnerException.Message);

                return null;
            }
        }

        public Task<IdentityResult> CreateUser(ApplicationUser user, string password)
        {
            try
            {
                return _userManager.CreateAsync(user, password);
            }
            catch (Exception e)
            {
                _logger.LogError(GetType().Name, "Username: " + user.UserName, e.Message,
                    e.InnerException == null ? "" : e.InnerException.Message);

                return null;
            }
        }

        public Task<ApplicationUser> GetUserByUsername(string username)
        {
            try
            {
                return _userManager.FindByNameAsync(username);
            }
            catch (Exception e)
            {
                _logger.LogError(GetType().Name, "Username: " + username, e.Message,
                    e.InnerException == null ? "" : e.InnerException.Message);

                return null;
            }
        }
    }
}
