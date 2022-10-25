using CleanCodeExample.Application.Common.Interfaces.Authentication;
using CleanCodeExample.Application.Common.Interfaces.Services;
using CleanCodeExample.Infrastructure.Authentication;
using CleanCodeExample.Infrastructure.DbConfiguration;
using CleanCodeExample.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CleanCodeExample.Infrastructure.Contexts;
using CleanCodeExample.Application.Common.Interfaces.Persistance;
using CleanCodeExample.Infrastructure.Persistance;
using Microsoft.Extensions.Caching.Memory;

namespace CleanCodeExample.Infrastructure;

public static class DependencyInjection{
    public static IServiceCollection AddInfrastructure(
                                            this IServiceCollection services,
                                            ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenereator, JwtTokenGenereator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IDealRepository, DealRepository>();
        services.Decorate<IDealRepository, CachedDealRepository>(); //use Scrutor
        //services.AddScoped<DealRepository>();
        //services.AddScoped<IDealRepository, CachedDealRepository>();
        //services.AddScoped<IDealRepository>(provider =>
        //{
        //    var dealRepository = provider.GetRequiredService<DealRepository>();
        //    return new CachedDealRepository(
        //        dealRepository,
        //        provider.GetService<IMemoryCache>()!);
        //});

        services.ConfigureOptions<DatabaseOptionsSetup>();

        services.AddDbContext<AppliconDealContext>(
            (serviceProvider, dbContextOptionsBuilder ) =>
            {
                var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

                dbContextOptionsBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                    sqlServerOptionsAction.CommandTimeout(databaseOptions.CommandTimeout);
                });

                dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
                dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);

            });

        return services;
    }
}