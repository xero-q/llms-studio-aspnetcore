using LLMStudio.Contracts.Requests;
using LLMStudio.Contracts.Responses;
using LLMStudio.Repositories;
using LLMStudio.Services;
using Microsoft.AspNetCore.Mvc;

namespace LLMStudio.Controllers;

[ApiController]
public class AuthController:ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    
    [HttpPost(ApiEndpoints.Auth.Login)]
    public async Task<ActionResult<LoginResponse>> LoginUser([FromBody] LoginRequest request)
    {
        var userPasswordCorrect = await _authenticationService.Authenticate(request.Username, request.Password);

        if (!userPasswordCorrect)
        {
            return Unauthorized();
        }
        
        var token = _authenticationService.GenerateToken(request.Username);

        var response = new LoginResponse
        {
            Token = token,
        };
            
        return Ok(response);
    }
}