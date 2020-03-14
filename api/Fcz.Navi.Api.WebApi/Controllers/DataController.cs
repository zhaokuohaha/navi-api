using System.Threading.Tasks;
using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

namespace Fcz.Navi.Api.Controllers
{
	[ApiController]
	[Route("api/controller")]
	public class DataController : ControllerBase
	{
		private readonly ILinkService _linkService;

		public DataController(ILinkService linkService)
		{
			_linkService = linkService;
		}

		[HttpGet("userName")]
		public async Task<ActionResult<LinkDataDto>> GetLinkData(string userName)
		{
			var data = await _linkService.GetLinkDataAsync(userName);
			if (data == null)
				return NotFound();
			return Ok(data); 
		}
	}
}