using DigitalCV.Data.Domain.Models;
using System.Threading.Tasks;

namespace DigitalCV.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<bool> CheckPassword(ApplicationUser user, string password);
    }
}
