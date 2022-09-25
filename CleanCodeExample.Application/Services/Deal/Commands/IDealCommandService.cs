 
using CleanCodeExample.Contracts.Authentication;

using CleanCodeExample.Contracts.Deals;
using ErrorOr;

namespace CleanCodeExample.Application.Services.Deal.Command;

public interface IDealCommandService
{
    Task<ErrorOr<DealResponse>> AddDealAsync(DealRequest dealRequest);
}