using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using DigitalCV.DTO.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DigitalCV.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Login(LoginDTO model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
        }
    }
}
