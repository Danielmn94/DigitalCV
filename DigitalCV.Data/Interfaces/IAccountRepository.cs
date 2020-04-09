using DigitalCV.DTO.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DigitalCV.Data.Interfaces
{
    public interface IAccountRepository
    {
        Task<SignInResult> Login(LoginDTO model);
    }
}
