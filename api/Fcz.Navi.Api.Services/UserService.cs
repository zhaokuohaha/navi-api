﻿using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Fcz.Navi.Api.Models.Entities;

namespace Fcz.Navi.Api.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _repo;
		public UserService(IServiceProvider service)
		{
			_repo = service.GetService<IUserRepository>();
		}

		public async Task AddUserAsync(UserDto userDto)
		{
			var user = new User { 
				Name = userDto.Name,
				Pwd = userDto.Pwd,
				CreateTime = DateTime.Now
			};
			await _repo.AddUserAsync(user);
		}

		public async Task<IEnumerable<string>> GetUsersAsync()
		{
			var users = await _repo.GetUsersAsync();
			return users.Select(u => u.Name);
		}

		public async Task<User> Get(string name)
		{
			return await _repo.Get(name);
		}

		public bool CheckPwd(User user, string password)
		{
			return user.Pwd == password;
		}
	}
}
