using CleanCodeExample.Application.Common.Interfaces.Persistance;
using CleanCodeExample.Application.Services.Deal;
using CleanCodeExample.Contracts.Authentication;
using CleanCodeExample.Contracts.Deals;
using CleanCodeExample.Domain.Common.Errors;
using CleanCodeExample.Domain.Entities;
using ErrorOr;

namespace CleanCodeExample.Application.Services.Deal.Queries;

public class DealQueryService : IDealQueryService
{
    private readonly IDealRepository _dealRepository;

    public DealQueryService(IDealRepository dealRepository)
    {
        _dealRepository = dealRepository;
    }
    public async Task<ErrorOr<List<DealResponse>>> GetDealsAsync()
    {
        var deals = await _dealRepository.GetDealsAsync();

        return   new List<DealResponse>();
    }


    public async Task<ErrorOr<DealResponse>> GetDealByNameAsync(string name)
    {
        var deal = await _dealRepository.GetDealByNameAsync(name);
        if(deal == null)
        {
            return Errors.Deal.NotFound;
        }

        return   new DealResponse();
    }

     
}