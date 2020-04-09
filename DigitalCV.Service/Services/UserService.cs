using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using DigitalCV.Service.Interfaces;
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

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<bool> CheckPassword(ApplicationUser user, string password)
        {
            return await _userRepository.CheckPassword(user, password);
        }
    }
}
