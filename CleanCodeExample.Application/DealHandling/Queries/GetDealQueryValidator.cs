using CleanCodeExample.Application.DealHandling.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExample.Application.DealHandling.Queries
{
    public class GetDealQueryValidator : AbstractValidator<GetDealQuery>
    {
        public GetDealQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
