using System;
using System.Collections.Generic;
using System.Text;
using Fcz.Navi.Api.Models.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Fcz.Navi.Api.Repositories
{
	public class RepositoryBase
	{
		protected readonly NaviDbContext _context;
		public RepositoryBase(NaviDbContext context)
		{
			_context = context;
		}
	}
}
