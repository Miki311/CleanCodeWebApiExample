using Microsoft.Extensions.DependencyInjection;
using ErrorOr;
using MediatR;
using CleanCodeExample.Application.DealHandling.Commands;
using CleanCodeExample.Contracts.Deals;
using CleanCodeExample.Application.Behaviors;
using FluentValidation;
using System.Reflection;

namespace CleanCodeExample.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehvior<,>));
        //services.AddScoped<IPipelineBehavior<AddDealComand, ErrorOr<DealResponseResult>>, ValidateAddDealCommandBehaviorOld>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        //services.AddScoped<IValidator<AddDealComand>, AddDealComandValidator>();

        //services.AddScoped<IAuthenticationService, AuthenticationService>();
        //services.AddScoped<IDealQueryService, DealQueryService>();
        //services.AddScoped<IDealCommandService, DealCommandService>();

        return services;
    }
}