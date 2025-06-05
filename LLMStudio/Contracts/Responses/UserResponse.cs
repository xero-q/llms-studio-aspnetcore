namespace LLMStudio.Contracts.Responses;

public class UserResponse
{
    public required int Id { get; set; }
    
    public required string Username { get; init; }
    
    public required string Password { get; init; }
}