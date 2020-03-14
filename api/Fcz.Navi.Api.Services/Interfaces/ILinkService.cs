using System.Collections.Generic;
using System.Threading.Tasks;
using Fcz.Navi.Api.Models.Dtos;

namespace Fcz.Navi.Api.Services
{
	public interface ILinkService
	{
		Task<IEnumerable<LinkDataDto>> GetLinkDataAsync(string userName);
	}
}