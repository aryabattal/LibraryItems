using ManageLibraryItemsAndEmployees.Areas.API.v2.Models;
using ManageLibraryItemsAndEmployees.Data.Entities;
using ManageLibraryItemsAndEmployeese.Areas.API.v2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ManageLibraryItemsAndEmployees.Areas.API.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("2")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Customer> userManager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<Customer> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult CreateToken(CredentialsDto credentialsDto)
        {
            var user = userManager.FindByNameAsync(credentialsDto.Username).Result;

            var hasAccess = userManager.CheckPasswordAsync(user, credentialsDto.Password).Result; 

            if (!hasAccess)
            {
                return Unauthorized(); // 401 Unauthorized
            }

            var token = GenerateToken(user);

            return Ok(token);
        }

        private TokenDto GenerateToken(Customer user)
        {
            var signingKey = Convert.FromBase64String(configuration["JWT:SigningKey"]);

            var claims = new List<Claim>();

            var roles = userManager.GetRolesAsync(user).Result;

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //claims.Add(new Claim(JwtRegisteredClaimNames.Sub, customer.UserName)),
            claims.Add(new Claim("address", user.Address));
            claims.Add(new Claim("firstName", user.FirstName));
            claims.Add(new Claim("lastName", user.LastName));
            claims.Add(new Claim("favoriteColor", "green"));

            // This is a placeholder for all the attributes related to the issued token.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),

                SigningCredentials = new SigningCredentials(
                  new SymmetricSecurityKey(signingKey),
                  SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            var token = new TokenDto
            {
                Value = jwtTokenHandler.WriteToken(jwtSecurityToken)
            };

            return token;
        }
    }
}
