using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExample.Infrastructure.DbConfiguration
{
    public  class DatabaseOptions
    {
        public const string  ConnectionStringDbName = "Database";
        public const string SectionName = "DatabaseOptions";
        public string ConnectionString { get; set; } = string.Empty;
        public int CommandTimeout { get; set; }
        public int MaxRetryCount { get; set; }
        public bool EnableDetailedErrors { get; set; }
        public bool EnableSensitiveDataLogging { get; set; }
    }
}
