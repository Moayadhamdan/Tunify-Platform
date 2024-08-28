using System.Security.Claims;
using TunifyPlatform.Models.DTO;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        // Add register
        public Task<AccountDto> RegisterUser(RegisterDto registerDto);

        // Add login
        public Task<AccountDto> UserAuthentication(string username, string password);

        // Add logout
        public Task<AccountDto> LogOut(string username);

        // Add Token
        public Task<AccountDto> GetToken(ClaimsPrincipal claimsPrincipal);
    }
}
