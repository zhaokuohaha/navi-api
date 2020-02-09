using Fcz.Navi.Api.Models.Entities;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.Repositories
{
	public class UserRepository : RepositoryBase, IUserRepository
	{
		public Task AddUserAsync(User user)
		{
			return Task.Delay(1000);
		}
	}
}
