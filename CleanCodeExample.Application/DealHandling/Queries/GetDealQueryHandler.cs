using CleanCodeExample.Application.Common.Interfaces.Persistance;
using CleanCodeExample.Contracts.Deals;
using CleanCodeExample.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExample.Application.DealHandling.Queries
{
    public class GetDealQueryHandler : IRequestHandler<GetDealQuery, ErrorOr<DealResponseResult>>
    {
        private readonly IDealRepository _dealRepository;

        public GetDealQueryHandler(IDealRepository dealRepository)
        {
            _dealRepository = dealRepository;
        }

        public async Task<ErrorOr<DealResponseResult>> Handle(GetDealQuery command, CancellationToken cancellationToken)
        {
            var response = await _dealRepository.GetDealByNameAsync(command.Name);
          
            //validate deal
            if (response is null)
            {
                return Errors.Deal.NotFound;
            }

            return new DealResponseResult();  
            
        }
    }
}
