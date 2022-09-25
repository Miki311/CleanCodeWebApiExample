using CleanCodeExample.Application.Common.Interfaces.Authentication;
using CleanCodeExample.Contracts.Authentication;
using global::CleanCodeExample.Application.Services.Authentication;

namespace CleanCodeExample.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenereator _jwtTokenGenerator;
     public AuthenticationService(IJwtTokenGenereator jwtTokenGenerator)
     {
         _jwtTokenGenerator = jwtTokenGenerator;
     }
    
    public AuthenticationResult Login (string email, string password){
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token"
        );
    }
    public AuthenticationResult Register (string firstName, string lastName, string email, string password){
        
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token
        );
    }
}