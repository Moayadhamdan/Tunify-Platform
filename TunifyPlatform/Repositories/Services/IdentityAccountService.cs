using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TunifyPlatform.Models;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class IdentityAccountService : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtTokenService _jwtTokenService;

        public IdentityAccountService(UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> signInManager, JwtTokenService jwtTokenService)
        {
            _userManager = manager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }

        // register
        public async Task<AccountDto> RegisterUser(RegisterDto registerDto)
        {
            var user = new ApplicationUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            await _userManager.AddToRolesAsync(user, registerDto.Roles);
            if (result.Succeeded)
            {
                return new AccountDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                
            };
            }
            return null;
        }

        // login
        public async Task<AccountDto> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                return new AccountDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await _jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(3)),
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }

            return null;
        }

        // logout
        public async Task<AccountDto> LogOut(string username)
        {
            var logoutAccount = await _userManager.FindByNameAsync(username);
            if (logoutAccount == null)
            {
                // Handle user not found case
                return null;
            }

            // Clear the authentication cookie or token here
            await _signInManager.SignOutAsync();

            var result = new AccountDto()
            {
                Id = logoutAccount.Id,
                Username = logoutAccount.UserName
            };

            return result;
        }

        public async Task<AccountDto> GetToken(ClaimsPrincipal claimsPrincipal)
        {
            var newToken = await _userManager.GetUserAsync(claimsPrincipal);
            if (newToken == null)
            {
                throw new InvalidOperationException("Token Is Not Exist!");
            }
            return new AccountDto()
            {
                Id = newToken.Id,
                Username = newToken.UserName,
                Token = await _jwtTokenService.GenerateToken(newToken, System.TimeSpan.FromMinutes(3)), // just for development purposes
                Roles = await _userManager.GetRolesAsync(newToken)
            };
        }
    }
}
