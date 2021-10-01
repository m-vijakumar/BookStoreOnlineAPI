using BookStoreOnlineAPI.Models.Dtos;
using BookStoreOnlineAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _services;

        public UserController(IUserService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers()
        {

            return Ok((List<UserReadDto>)await _services.GetUsers());
        }

        [Route("auth/register")]
        [HttpPost]
        public async Task<ActionResult<UserReadDto>> Create(UserCreateDto userCreateDto)
        {
            UserReadDto user = await _services.Create(userCreateDto);
            if (user == null)
            {
                return BadRequest();
            }
            return user;
        }

        [HttpGet]
        [Route("validateUserName/{UserName}")]
        public async Task<ActionResult<bool>> ValidateUserName(string UserName)
        {
           bool user = await _services.CheckUserAvailabity(UserName);

            return user;
        }
    }
}
