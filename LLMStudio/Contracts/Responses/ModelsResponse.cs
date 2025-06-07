namespace LLMStudio.Contracts.Responses;

public class ModelsResponse
{
    public IEnumerable<ModelResponse> Items { get; init; } = [];
}