namespace LLMStudio.Contracts.Responses;

public class ModelTypesResponse
{
    public IEnumerable<ModelTypeResponse> Items { get; init; } = [];
}