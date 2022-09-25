using CleanCodeExample.Api.Common.Errors;
using CleanCodeExample.Api.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
 

namespace CleanCodeExample.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        //services.AddControllers();
        //services.AddSingleton<ProblemDetailsFactory, CleanCodeProblemDetailsFactory>();
        services.AddMapping();
         
        return services;
    }
}