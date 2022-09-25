using CleanCodeExample.Domain;
using CleanCodeExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExample.Application.Common.Interfaces.Persistance
{
    public interface IDealRepository 
    {
        Task<List<Deal>> GetDealsAsync();
        Task<Deal> GetDealByIdAsync(int id);

        Task<int> AddDealAsync(Deal deal);
        Task SaveAsync();
    }
}
