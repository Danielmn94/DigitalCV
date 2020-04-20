using DigitalCV.Data.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DigitalCV.Service.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserByEmail(string email);

        Task<bool> CheckPassword(ApplicationUser user, string password);

        Task<IdentityResult> CreateUser(ApplicationUser appUser, string password);

        ApplicationUser CreateApplicationUser(string username);

        Task<ApplicationUser> GetUserByUsername(string username);
    }
}
