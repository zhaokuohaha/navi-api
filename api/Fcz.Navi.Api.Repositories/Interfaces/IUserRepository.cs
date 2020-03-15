using Fcz.Navi.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.Repositories
{
	public interface IUserRepository
	{
		Task AddUserAsync(User user);
		Task<IEnumerable<User>> GetUsersAsync();
		Task<User> Get(string name);
	}
}
