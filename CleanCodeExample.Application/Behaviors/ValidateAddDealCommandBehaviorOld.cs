using CleanCodeExample.Application.DealHandling.Commands;
using CleanCodeExample.Contracts.Deals;
using ErrorOr;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExample.Application.Behaviors
{
    public class ValidateAddDealCommandBehaviorOld : IPipelineBehavior<AddDealComand, ErrorOr<DealResponseResult>>
    {

        private readonly IValidator<AddDealComand> _validator;

        public ValidateAddDealCommandBehaviorOld(IValidator<AddDealComand> validator)
        {
            _validator = validator;
        }

        public async Task<ErrorOr<DealResponseResult>> Handle(AddDealComand request, 
                                                        CancellationToken cancellationToken, 
                                                        RequestHandlerDelegate<ErrorOr<DealResponseResult>> next)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
           
            if(validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors.
                     ConvertAll(validationFailure => Error.Validation(
                            validationFailure.PropertyName,
                            validationFailure.ErrorMessage));
                   

            return errors;
        }
    }
}
