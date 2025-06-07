using LLMStudio.Contracts.Requests;
using LLMStudio.Contracts.Responses;
using LLMStudio.Repositories;
using LLMStudio.Services;
using Microsoft.AspNetCore.Mvc;

namespace LLMStudio.Controllers;

[ApiController]
public class AuthController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost(ApiEndpoints.Auth.Login)]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest request)
    {
        var userPasswordCorrect = await authenticationService.Authenticate(request.Username, request.Password);

        if (!userPasswordCorrect)
        {
            return Unauthorized();
        }
        
        var token = authenticationService.GenerateToken(request.Username);

        var response = new LoginResponse
        {
            Token = token,
        };
            
        return Ok(response);
    }
}