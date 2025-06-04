using LLMStudio.Contracts.Requests;
using LLMStudio.Contracts.Responses;
using LLMStudio.Data.Models;

namespace LLMStudio.Mappings;

public static class ContractMappings
{
    public static ModelType MapToModelType(this CreateModelTypeRequest request)
    {
        return new ModelType
        {
            Name = request.Name

        };
    }
    
    public static CreateModelTypeResponse MapToResponse(this ModelType modelType)
    {
        return new CreateModelTypeResponse
        {
            Id = modelType.Id,
            Name = modelType.Name
        };
    }
}