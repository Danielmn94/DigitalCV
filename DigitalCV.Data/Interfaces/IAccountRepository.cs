using DigitalCV.Data.Domain.Models;
using DigitalCV.DTO.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DigitalCV.Data.Interfaces
{
    public interface IAccountRepository
    {
        Task<SignInResult> LoginPassword(LoginDTO model);
        Task Login(ApplicationUser user);
    }
}
