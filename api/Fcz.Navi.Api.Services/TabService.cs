using Fcz.Navi.Api.Repositories;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Fcz.Navi.Api.Models.Entities;

namespace Fcz.Navi.Api.Services
{
    public class TabService : ITabService
    {
        private readonly ITabRepository _repo;

        public TabService(IServiceProvider service)
        {
            _repo = service.GetService<ITabRepository>();
        }

        public async Task Create(Tab tab)
        {
            tab.CreateTime = DateTime.Now;
            await _repo.Create(tab);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }
    }
}
