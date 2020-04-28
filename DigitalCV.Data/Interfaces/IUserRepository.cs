using DigitalCV.Data.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DigitalCV.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CheckPassword(ApplicationUser user, string password);

        ApplicationUser CreateApplicationUser(string username);

        Task<IdentityResult> CreateUser(ApplicationUser user, string password);

        Task<ApplicationUser> GetUserByUsername(string username);
    }
}
