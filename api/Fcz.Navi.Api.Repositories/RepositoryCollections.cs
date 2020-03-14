using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Fcz.Navi.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fcz.Navi.Api.Repositories
{
	public static class RepositoryCollections
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration conf)
		{
			services.AddDbContext<NaviDbContext>(options =>
				options.UseMySql(conf.GetConnectionString("Navi")));

			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<ILinkRepository, LinkRepository>();
			return services;
		}
	}
}
