using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AB_APP_Slopes_API.Models; // Create this model to define login and register DTOs
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AB_APP_Slopes_API.Models.DTOs;

namespace SimpleApiWithAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        // POST: api/authentication/register
        [HttpPost("register")]
        public RegisterResultDTO Register([FromBody] RegisterModel model)
        {
            var resultDTO = new RegisterResultDTO();

            if (!ModelState.IsValid)
            {
                resultDTO.Errors = new List<string> { "Invalid model state." };
                return resultDTO;
            }

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = _userManager.CreateAsync(user, model.Password).Result;

            if (result.Succeeded)
            {
                // Optionally sign the user in after registration
                _signInManager.SignInAsync(user, isPersistent: false).Wait();
                return new RegisterResultDTO(); // No errors, registration succeeded
            }

            resultDTO.Errors = result.Errors.Select(e => $"{e.Code}: {e.Description}").ToList();
            return resultDTO;
        }

        // POST: api/authentication/login
        [HttpPost("login")]
        public LoginResultDTO Login([FromBody] LoginModel model)
        {
            var resultDTO = new LoginResultDTO();

            if (!ModelState.IsValid)
            {
                resultDTO.Errors = new List<string> { "Invalid model state." };
                return resultDTO;
            }

            var user = _userManager.FindByEmailAsync(model.Email).Result;
            if (user == null)
            {
                resultDTO.Errors = new List<string> { "Invalid login attempt" };
                return resultDTO;
            }

            var passwordValid =  _userManager.CheckPasswordAsync(user, model.Password).Result;
            if (!passwordValid)
            {
                resultDTO.Errors = new List<string> { "Invalid password" };

            }

            var result = _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false).Result;

            if (result.Succeeded)
            {
                resultDTO.Token = GenerateJwtToken(user).Result;
                resultDTO.UserId = user.Id;
                resultDTO.UserEmail = user.Email;
                resultDTO.UserName = user.UserName;
                return resultDTO;
            }
            else if (result.IsLockedOut)
            {
                resultDTO.Errors = new List<string> { "User account locked out" };
            }
            else
            {
                resultDTO.Errors = new List<string> { "Invalid login attempt" };
            }

            return resultDTO;
        }

        private async Task<string> GenerateJwtToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            // Add roles as claims if you have role-based authorization
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:TokenLifetimeInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        // POST: api/authentication/logout
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { Message = "User logged out" });
        }
    }
}
