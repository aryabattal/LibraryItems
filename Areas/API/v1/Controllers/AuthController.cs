using ManageLibraryItemsAndEmployees.Areas.API.v1.Models;
using ManageLibraryItemsAndEmployees.Data.Entities;
using ManageLibraryItemsAndEmployeese.Areas.API.v1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ManageLibraryItemsAndEmployees.Areas.API.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        /// <summary>
        /// Generate authentication token
        /// </summary>
        /// <param name="credentialsDto">User credentials</param>
        /// <returns>Token</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        private TokenDto GenerateToken(IdentityUser user)
        {
            var signingKey = Convert.FromBase64String(configuration["JWT:SigningKey"]);

            var claims = new List<Claim>();

            var roles = userManager.GetRolesAsync(user).Result;

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //claims.Add(new Claim(JwtRegisteredClaimNames.Sub, customer.UserName)),
            claims.Add(new Claim("mailAddress", user.Email));
            claims.Add(new Claim("usertName", user.UserName));


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
