using System;
using System.Collections.Generic;
using System.Linq;
using Fcz.Navi.Api.Models.Entities;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.Repositories
{
	public class UserRepository : RepositoryBase, IUserRepository
	{
		public UserRepository(NaviDbContext context) : base(context)
		{
		}


		public Task AddUserAsync(User user)
		{
			return Task.Delay(1000);
		}

		public async Task<IEnumerable<User>> GetUsersAsync()
		{
			return _context.Users.Where(u => u.DeleteTime == null);
		}
	}
}
