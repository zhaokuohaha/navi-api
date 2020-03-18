using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Models.Entities;
using Fcz.Navi.Api.Models.Extensions;
using Fcz.Navi.Api.Repositories;
using Fcz.Navi.Api.Services.Internal;
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

		public async Task Create(Link link)
		{
			link.CreateTime = DateTime.Now;

			await DetectIcon(link);

			await _repo.Insert(link);
		}

		public async Task Update(LinkDataDto dto)
		{
			var link = await _repo.Find(dto.Id);
			if (link == null)
				throw new FakeHttpException(HttpStatusCode.NotFound);

			link.Title = dto.Title;
			link.Url = dto.Url;

			link.BgColor = dto.BgColor.IsNullOrEmpty() ? link.BgColor : dto.BgColor;
			link.Icon = dto.Icon.IsNullOrEmpty() ? link.Icon : dto.Icon;

			await DetectIcon(link);

			await _repo.Update(link);
		}

		private async Task DetectIcon(Link link)
		{
			if (link.Icon.IsNullOrEmpty())
			{
				link.Icon = await LinkHelper.GetFavicon(link.Url);
			}

			if (link.BgColor.IsNullOrEmpty() && !link.Icon.IsNullOrEmpty())
			{
				link.BgColor = await LinkHelper.GetMainColor(link.Icon);
			}
		}

		public async Task Delete(int id)
		{
			await _repo.Delete(id);
		}
	}
}