using Fcz.Navi.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.Services
{
	public interface ITabService
	{
		Task Create(Tab tab);
		Task Delete(int id);
	}
}
