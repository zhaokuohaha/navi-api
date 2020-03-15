using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.Services
{
	public interface IUserService
	{
		Task AddUserAsync(UserDto userDto);
		Task<IEnumerable<string>> GetUsersAsync();
		Task<User> Get(string name);
		bool CheckPwd(User user, string password);
	}
}
