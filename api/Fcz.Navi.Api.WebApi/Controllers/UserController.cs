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
    [Route("api/[controller]")]
    [ApiController]
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
    }
}