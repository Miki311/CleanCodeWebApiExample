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

namespace CleanCodeExample.Application.DealHandling.Commands
{
    public class AddDealComandHandler : IRequestHandler<AddDealComand, ErrorOr<DealResponseResult>>
    {
        private readonly IDealRepository _dealRepository;

        public AddDealComandHandler(IDealRepository dealRepository)
        {
            _dealRepository = dealRepository;
        }

        public async Task<ErrorOr<DealResponseResult>> Handle(AddDealComand command, CancellationToken cancellationToken)
        {
            //await Task.CompletedTask;
            
            //validate deal
            if(_dealRepository.GetDealByIdAsync(command.Id) is not null)
            {
                return Errors.Deal.AlreadyExists;
            }

            //create deal / mock get deal by id 
            var deal = new Domain.Entities.Deal { Id = command.Id, Name = command.Name, Description = command.Description };

            var id = await _dealRepository.AddDealAsync(deal);

            if (id != 0) { return new DealResponseResult { Id = deal.Id, Name = deal.Name, Description = deal.Description, Objection = String.Empty };  }
            return Errors.Deal.NotFound;
        }
    }
}
