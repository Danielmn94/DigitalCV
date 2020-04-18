using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DigitalCV.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> CheckPassword(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public ApplicationUser CreateApplicationUser(string username)
        {
            return new ApplicationUser { UserName = username };
        }

        public Task<IdentityResult> CreateUser(ApplicationUser user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task<ApplicationUser> GetUserByUsername(string username)
        {
            return _userManager.FindByNameAsync(username);
        }
    }
}
