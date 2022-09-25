using CleanCodeExample.Contracts;
using CleanCodeExample.Contracts.Authentication;
 
using CleanCodeExample.Contracts.Deals;
using ErrorOr;

namespace CleanCodeExample.Application.Services.Deal.Queries;

public interface IDealQueryService
{
    Task<ErrorOr<List<DealResponse>>> GetDealsAsync();
    Task<ErrorOr<DealResponse>> GetDealByIdAsync (int id);
  
}