namespace LLMStudio.Contracts.Requests;

public class CreateUserRequest
{
    public required string Username { get; init; }
    
    public required string Password { get; init; }
}