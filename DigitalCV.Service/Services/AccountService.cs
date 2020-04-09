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

        public async Task<SignInResult> Login(LoginDTO model)
        {
            return await _accountRepository.Login(model);
        }
    }
}
