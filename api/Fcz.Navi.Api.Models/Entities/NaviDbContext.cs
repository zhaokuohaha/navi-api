using Microsoft.EntityFrameworkCore;

namespace Fcz.Navi.Api.Models.Entities
{
	public class NaviDbContext : DbContext
	{
		public NaviDbContext(DbContextOptions options) : base(options)
		{

		}

		
		public DbSet<User> Users { get; set; }
		public DbSet<Tab> Tabs { get; set; }
		public DbSet<Link> Links { get; set; }
	}
}