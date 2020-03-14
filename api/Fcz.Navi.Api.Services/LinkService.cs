using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Models.Entities;
using Fcz.Navi.Api.Models.Extensions;
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

		public async Task Create(Link link)
		{
			link.CreateTime = DateTime.Now;
			if (link.Icon.IsNullOrEmpty())
			{
				// TODO FCZ 20200314 解析favicon
			}
			if (link.BgColor.IsNullOrEmpty())
			{
				// TODO FCZ 20200314 解析背景色主色
			}

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

			await _repo.Update(link);
		}

		public async Task Delete(int id)
		{
			var link = await _repo.Find(id);
			if (link == null)
				throw new FakeHttpException(HttpStatusCode.NotFound);

			link.DeleteTime = DateTime.Now;
			await _repo.Update(link);
		}
	}
}