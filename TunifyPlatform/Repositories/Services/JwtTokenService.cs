using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Services
{
    public class JwtTokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public JwtTokenService(IConfiguration configuration, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public static TokenValidationParameters ValidateToken(IConfiguration configuration)
        {
            return new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }

        public static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secretKey = configuration["JWT:SecretKey"];
            if (secretKey == null)
            {
                throw new InvalidOperationException("jwt secret key is not exist");
            }

            var secretBytes = Encoding.UTF8.GetBytes(secretKey);

            return new SymmetricSecurityKey(secretBytes);
        }


        public async Task<string> GenerateToken(ApplicationUser user, TimeSpan expiryDate)
        {
            var userPrincliple = await _signInManager.CreateUserPrincipalAsync(user);
            if (userPrincliple == null)
            {
                return null;
            }
            var newClaims = userPrincliple.Claims.ToList();
            var userParmation = await _userManager.GetClaimsAsync(user);
            newClaims.AddRange(userParmation);
            var signInKey = GetSecurityKey(_configuration);

            var token = new JwtSecurityToken
                (
                expires: DateTime.UtcNow + expiryDate,
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256),
                claims: newClaims
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
