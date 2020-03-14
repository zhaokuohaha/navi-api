using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.Repositories
{
	public interface ILinkRepository
	{
		Task<IEnumerable<LinkDataDto>> GetLinkDataAsync(string userName);
		Task<Link> Find(int id);
		Task Update(Link link);
		Task Insert(Link link);
	}
}
