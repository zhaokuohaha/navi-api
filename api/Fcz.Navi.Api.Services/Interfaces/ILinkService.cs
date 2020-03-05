using System.Threading.Tasks;
using Fcz.Navi.Api.Models.Dtos;

namespace Fcz.Navi.Api.Services
{
	public interface ILinkService
	{
		Task<LinkDataDto> GetLinkDataAsync(string userName);
	}
}