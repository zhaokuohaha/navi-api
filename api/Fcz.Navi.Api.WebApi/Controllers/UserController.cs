using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fcz.Navi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [HttpPost]
        public async Task AddUser(UserDto userDto)
        {
            await _service.AddUserAsync(userDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetUsers()
        {
	        var users = await _service.GetUsersAsync();
	        return Ok(users);
        }
    }
}