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


		public async Task AddUserAsync(User user)
		{
			await _context.AddAsync(user);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<User>> GetUsersAsync()
		{
			return _context.Users.Where(u => u.DeleteTime == null);
		}

		public async Task<User> Get(string name)
		{
			var user = _context.Users.FirstOrDefault(u => u.Name == name && !u.DeleteTime.HasValue);
			return user;
		}
	}
}
