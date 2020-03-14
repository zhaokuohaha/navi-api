using System.Collections.Generic;
using System.Threading.Tasks;
using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Models.Entities;

namespace Fcz.Navi.Api.Services
{
	public interface ILinkService
	{
		Task<IEnumerable<LinkDataDto>> GetLinkDataAsync(string userName);
		Task Update(LinkDataDto dto);
		Task Delete(int id);
		Task Create(Link link);
	}
}