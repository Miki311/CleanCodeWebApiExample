using CleanCodeExample.Application.Common.Interfaces.Persistance;
using CleanCodeExample.Domain;
using CleanCodeExample.Domain.Entities;
using CleanCodeExample.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExample.Infrastructure.Persistance
{
    public class DealRepository : IDealRepository
    {
        private readonly AppliconDealContext _dbContext;

        public DealRepository(AppliconDealContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Deal>> GetDealsAsync()
        {
            return await _dbContext.Deals.ToListAsync();
            //return Task.FromResult(new List<Deal>());
        }

        public async Task<Deal> GetDealByNameAsync(string name)
        {
            Task<Deal?> task = _dbContext.Deals.Where(b => b.Name.Equals(name)).FirstOrDefaultAsync();
            return await task;
            //return Task.FromResult(new Deal());
        }

        public async Task<int> AddDealAsync(Deal deal)
        {
            _dbContext.Deals.Add(deal);
            await SaveAsync();
            return deal.Id;
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
