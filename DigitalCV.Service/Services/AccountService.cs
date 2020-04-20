using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using DigitalCV.DTO.DTOs;
using DigitalCV.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DigitalCV.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<SignInResult> LoginPassword(LoginDTO model)
        {
            return await _accountRepository.LoginPassword(model);
        }

        public Task Login(ApplicationUser appUser)
        {
            return _accountRepository.Login(appUser);
        }

        public void LogOut()
        {
            _accountRepository.LogOut();
        }
    }
}
