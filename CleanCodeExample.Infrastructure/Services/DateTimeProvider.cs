using CleanCodeExample.Application.Common.Interfaces.Services;
namespace CleanCodeExample.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
   public DateTime UtcNow => DateTime.UtcNow;
}