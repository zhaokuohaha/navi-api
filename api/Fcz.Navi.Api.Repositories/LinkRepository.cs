using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.Repositories
{
	public class LinkRepository : RepositoryBase, ILinkRepository
	{
		public LinkRepository(NaviDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<LinkDataDto>> GetLinkDataAsync(string userName)
		{
			if (string.IsNullOrEmpty(userName))
				return Enumerable.Empty<LinkDataDto>();

			//var data = _context.Users.Where(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
			var data = from user in _context.Users
					   join tab in _context.Tabs on user.Id equals tab.UserId
					   join link in _context.Links on tab.Id equals link.TabId
					   where user.Name.Equals(userName) && !user.DeleteTime.HasValue && !link.DeleteTime.HasValue
					   select new LinkDataDto
					   {
						   TabId = tab.Id,
						   TabTitle = tab.Title,
						   Id = link.Id,
						   Title = link.Title,
						   Url = link.Url,
						   Icon = link.Icon,
						   BgColor = link.BgColor,
						   CreateTime = link.CreateTime
					   };
			return data;		
		}
	}
}
