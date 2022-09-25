using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
 

namespace CleanCodeExample.Infrastructure.DbConfiguration
{
    public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
    {
        private readonly IConfiguration _configuration;

        public DatabaseOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(DatabaseOptions options)
        {
            options.ConnectionString = _configuration.GetConnectionString(DatabaseOptions.ConnectionStringDbName);
            _configuration.GetSection(DatabaseOptions.SectionName).Bind(options);

        }
    }
}
