using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using DigitalCV.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DigitalCV.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CheckPassword(ApplicationUser user, string password)
        {
            return await _userRepository.CheckPassword(user, password);
        }

        public Task<IdentityResult> CreateUser(ApplicationUser appUser,string password)
        {
            return _userRepository.CreateUser(appUser,password);
        }

        public ApplicationUser CreateApplicationUser(string username)
        {
            return _userRepository.CreateApplicationUser(username);
        }

        public Task<ApplicationUser> GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }
    }
}
