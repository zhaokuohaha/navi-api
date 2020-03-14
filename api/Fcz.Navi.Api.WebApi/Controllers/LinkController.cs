using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Models.Entities;
using Fcz.Navi.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class LinkController : ControllerBase
	{
		private readonly ILinkService _linkService;

		public LinkController(ILinkService linkService)
		{
			_linkService = linkService;
		}

		[HttpPost]
		public async Task<ActionResult> Create([FromBody] Link link)
		{
			await _linkService.Create(link);
			return Ok();
		}

		[HttpPatch]
		public async Task<ActionResult> Edit([FromBody]LinkDataDto dto)
		{
			if (dto.Id <= 0 || dto.TabId <= 0)
				return BadRequest($"参数错误, {(dto.Id <= 0 ? "Id" : "TabId")} 无意义");
			await _linkService.Update(dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<bool>> Delete(int id)
		{
			if (id <= 0)
				return BadRequest("参数错误, Id必须大于零");

			await _linkService.Delete(id);
			return Ok(true);
		}
	}
}
