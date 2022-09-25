namespace   CleanCodeExample.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenereator
{
    string GenerateToken (Guid userId, string firstName, string lastName);
}