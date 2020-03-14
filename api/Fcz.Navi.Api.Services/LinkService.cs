using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Fcz.Navi.Api.Services
{
	public class LinkService : ILinkService
	{
		private readonly ILinkRepository _repo;
		public LinkService(IServiceProvider service)
		{
			_repo = service.GetService<ILinkRepository>();
		}
		public async Task<IEnumerable<LinkDataDto>> GetLinkDataAsync(string userName)
		{
			return await _repo.GetLinkDataAsync(userName);
		}
	}
}