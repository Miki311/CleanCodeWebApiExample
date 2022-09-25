using CleanCodeExample.Application.Common.Interfaces.Persistance;
 
using CleanCodeExample.Contracts.Authentication;
using CleanCodeExample.Contracts.Deals;
using CleanCodeExample.Domain.Common.Errors;
using CleanCodeExample.Domain.Entities;
using ErrorOr;

namespace CleanCodeExample.Application.Services.Deal.Command;

public class DealCommandService : IDealCommandService
{
    private readonly IDealRepository _dealRepository;

    public DealCommandService(IDealRepository dealRepository)
    {
        _dealRepository = dealRepository;
    }

    public async Task<ErrorOr<DealResponse>> AddDealAsync(DealRequest dealRequest)
    {
        var deal = new Domain.Entities.Deal { Id = dealRequest.Id, Name = dealRequest.Name, Description = dealRequest.Description };
        var id = await _dealRepository.AddDealAsync(deal);

        if (id != 0) { return new DealResponse(); ; }
        return Errors.Deal.NotFound;

    }
}