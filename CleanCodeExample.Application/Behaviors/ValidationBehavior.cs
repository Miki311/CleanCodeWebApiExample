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
    public class ValidationBehvior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
                            where TRequest : IRequest<TResponse>
                            where TResponse: IErrorOr
    {

        private readonly IValidator<TRequest>? _validator;

        public ValidationBehvior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
           
            if(validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors.
                     ConvertAll(validationFailure => Error.Validation(
                            validationFailure.PropertyName,
                            validationFailure.ErrorMessage));
                   

            return (dynamic)errors;
        }

         
    }
}
