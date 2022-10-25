using CleanCodeExample.Application.Common.Interfaces.Persistance;
using CleanCodeExample.Domain;
using CleanCodeExample.Domain.Entities;
using CleanCodeExample.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExample.Infrastructure.Persistance
{
    public class CachedDealRepository : IDealRepository
    {
        private readonly IDealRepository _decorated; //because of Scrutor, use Interface
        private readonly IMemoryCache _memoryCache;

        public CachedDealRepository(DealRepository decorated, IMemoryCache memoryCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }

        public async Task<List<Deal>> GetDealsAsync()
        {
            return await _decorated.GetDealsAsync();
            
        }

        public Task<Deal> GetDealByNameAsync(string name)
        {
            string key = $"deal-{name}";
            return _memoryCache.GetOrCreateAsync(
                key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                    return _decorated.GetDealByNameAsync(name);
                });
        }

        public async Task<int> AddDealAsync(Deal deal)
        {
            return deal.Id;
        }
        public async Task SaveAsync()
        {
            return;
        }
    }
}
