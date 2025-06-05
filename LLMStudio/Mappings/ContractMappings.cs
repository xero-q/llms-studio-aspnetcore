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
    
    public static ModelTypeResponse MapToResponse(this ModelType modelType)
    {
        return new ModelTypeResponse
        {
            Id = modelType.Id,
            Name = modelType.Name
        };
    }
    
    public static ModelTypesResponse MapToResponse(this IEnumerable<ModelType> modelTypes)
    {
        return new ModelTypesResponse
        {
            Items = modelTypes.Select(MapToResponse)
        };
    }
    
}