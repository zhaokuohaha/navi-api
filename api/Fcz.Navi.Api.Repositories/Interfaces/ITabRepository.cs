using Fcz.Navi.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.Repositories
{
	public interface ITabRepository
	{
		Task<Tab> Find(int id);
		Task Create(Tab tab);
		Task Update(Tab tab);
		Task Delete(int id);
	}
}
