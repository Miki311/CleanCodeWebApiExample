using CleanCodeExample.Contracts.Deals;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExample.Application.DealHandling.Commands
{
    public class AddDealComand : IRequest<ErrorOr<DealResponseResult>>
    {
        public AddDealComand(int id, string name, string description, string objection)
        {
            Id = id;
            Name = name;
            Description = description;
            Objection = objection;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Objection { get; set; }
    }
}
