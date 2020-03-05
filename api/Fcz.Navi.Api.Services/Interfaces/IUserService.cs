using Fcz.Navi.Api.Models.Dtos;
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
	}
}
