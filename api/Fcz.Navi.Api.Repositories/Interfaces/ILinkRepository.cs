using Fcz.Navi.Api.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.Repositories
{
	public interface ILinkRepository
	{
		Task<IEnumerable<LinkDataDto>> GetLinkDataAsync(string userName);
	}
}
