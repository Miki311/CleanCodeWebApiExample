using CleanCodeExample.Api.Filters;
using CleanCodeExample.Application.Services.Authentication;
using CleanCodeExample.Application.Services.Deal;
using CleanCodeExample.Contracts.Authentication;
using CleanCodeExample.Contracts.Deals;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeExample.Api.Controllers;

[ApiController]
[Route("auth")]
//[ErrorHandlingFilter]
public class AuthenticationController : ApiController
{ 
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService){
        _authenticationService = authenticationService;
    }


    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.FirstName,
                                                         request.LastName, 
                                                         request.Email, 
                                                         request.Password );
        
        var response =  new AuthenticationResponse{
            Id = authResult.Id,
            FirstName = authResult.FirstName,
            LastName = authResult.LastName,
            Email = authResult.Email,
            Token = authResult.Token
        };

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(  
                                                     request.Email, 
                                                     request.Password );
        
        var response =  new AuthenticationResponse {
            Id = authResult.Id,
            FirstName = authResult.FirstName,
            LastName = authResult.LastName,
            Email = authResult.Email,
            Token = authResult.Token 
        };
            
        return Ok(response);
    }
}
