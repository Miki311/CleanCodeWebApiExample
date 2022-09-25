using CleanCodeExample.Application.DealHandling.Commands;
using CleanCodeExample.Application.DealHandling.Queries;
using CleanCodeExample.Contracts.Deals;
using CleanCodeExample.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeExample.Api.Controllers;

[ApiController]
[Route("deal-management")]
//[ErrorHandlingFilter]
public class DealController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public DealController(IMediator mediator, IMapper mapper) 
    {
        _mediator = mediator; 
        _mapper = mapper; 
    }

    [HttpPost]
    [Route("deals")]
    public async Task<IActionResult> AddDeal(DealRequest dealRequest)
    {
        //var command = new AddDealComand(dealRequest.Id, dealRequest.Name, dealRequest.Description, dealRequest.Objection);
        //dealRequest => AddDealComand
        var command = _mapper.Map<AddDealComand>(dealRequest);
        ErrorOr<DealResponseResult> _dealResponse = await _mediator.Send(command);
        
        return _dealResponse.Match(
                       created => Ok(_mapper.Map<DealResponse>(_dealResponse)),
                       errors => Problem(errors)
                );
    }

    [HttpGet]
    [Route("deals")]
    public async Task<IActionResult> GetDeal(DealRequest dealRequest)
    {
        var query = _mapper.Map<GetDealQuery>(dealRequest.Id);
        //var query = new GetDealQuery(id);
        ErrorOr<DealResponseResult> dealResult = await _mediator.Send(query);
        
        if(dealResult.IsError && dealResult.FirstError == Errors.Deal.NotFound)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: dealResult.FirstError.Description);
        }


        return dealResult.Match(
            deal => Ok(_mapper.Map<DealResponse>(dealResult)),
            errors => Problem(errors));
    }
}