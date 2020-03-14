using Fcz.Navi.Api.Models.Entities;
using Fcz.Navi.Api.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.Repositories
{
    public class TabRepository : RepositoryBase, ITabRepository
    {
        public TabRepository(NaviDbContext context) : base(context)
        {
        }

        public async Task<Tab> Find(int id)
        {
            return await _context.Tabs.FindAsync(id);
        }

        public async Task Create(Tab tab)
        {
            await _context.Tabs.AddAsync(tab);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Tab tab)
        {
            _context.Tabs.Update(tab);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var tab = await Find(id);
            if (tab == null || tab.DeleteTime.HasValue)
                throw new FakeHttpException(System.Net.HttpStatusCode.NotFound);

            tab.DeleteTime = DateTime.Now;
            await Update(tab);
        }
    }
}
