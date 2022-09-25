using CleanCodeExample.Contracts.Deals;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExample.Application.DealHandling.Queries
{
    public class GetDealQuery : IRequest<ErrorOr<DealResponseResult>>
    {
        public GetDealQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
