using DigitalCV.Data.Domain.Models;
using DigitalCV.DTO.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DigitalCV.Service.Interfaces
{
    public interface IAccountService
    {
        Task<SignInResult> LoginPassword(LoginDTO model);

        Task Login(ApplicationUser appUser);
    }
}
