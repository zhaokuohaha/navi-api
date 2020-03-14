using Fcz.Navi.Api.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fcz.Navi.Api.Services
{
	public static class ServicesCollection
	{
		public static IServiceCollection AddNaviService(this IServiceCollection services, IConfiguration conf)
		{
			
			services.AddRepositories(conf);

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ILinkService, LinkService>();
			return services;
		}
	}
}
