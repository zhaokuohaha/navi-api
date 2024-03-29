﻿using Fcz.Navi.Api.Models.Entities;
using Fcz.Navi.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TabController : ControllerBase
    {
        private readonly ITabService _tabService;
        public TabController(ITabService tabService)
        {
            _tabService = tabService;
        }

        [HttpPatch]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] Tab tab)
        {
            return BadRequest("未实现");
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddTab([FromBody] Tab tab)
        {
            var user = User.FindFirst("Id").Value;
            if (!int.TryParse(user, out var userId))
                return Unauthorized($"{user} 不存在");

            tab.UserId = userId;
            await _tabService.Create(tab);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteTab(int id)
        {
            await _tabService.Delete(id);
            return Ok();
        }
    }
}
