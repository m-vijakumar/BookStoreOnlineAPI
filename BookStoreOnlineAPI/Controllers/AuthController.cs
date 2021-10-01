using BookStoreOnlineAPI.Models;
using BookStoreOnlineAPI.Models.Dtos;
using BookStoreOnlineAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Globalization;
using System.Text;

namespace BookStoreOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IConfiguration _config;
        public AuthController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<object>> Login(UserLoginDto login)
        {

            UserReadDto user = await _userService.AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                return Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            else
            {
                return Unauthorized();
            }
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<UserReadDto>> Create(UserCreateDto userCreateDto)
        {
            UserReadDto user = await _userService.Create(userCreateDto);
            if (user == null)
            {
                return BadRequest();
            }
            var tokenString = GenerateJSONWebToken(user);
            return Ok(new
            {
                token = tokenString,
                userDetails = user,
            });
           
        }

        string GenerateJSONWebToken(UserReadDto userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("UserId", userInfo.UserId.ToString(CultureInfo.InvariantCulture)),

                new Claim(ClaimTypes.Role,2.ToString(CultureInfo.InvariantCulture)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
