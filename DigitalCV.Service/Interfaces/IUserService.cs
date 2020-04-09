using DigitalCV.Data.Domain.Models;
using System.Threading.Tasks;

namespace DigitalCV.Service.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserByEmail(string email);

        Task<bool> CheckPassword(ApplicationUser user, string password);
    }
}
