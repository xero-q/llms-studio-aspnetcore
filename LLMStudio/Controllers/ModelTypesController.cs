using LLMStudio;
using LLMStudio.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using LLMStudio.Data.Models;
using LLMStudio.Mappings;
using LLMStudio.Repositories;

[ApiController]
public class ModelTypesController : ControllerBase
{
    private readonly IModelTypeRepository _modelTypeRepository;

    public ModelTypesController(IModelTypeRepository modelTypeRepository)
    {
        _modelTypeRepository = modelTypeRepository;
    }
    
    [HttpPost(ApiEndpoints.ModelTypes.Create)]
    public async Task<ActionResult<ModelType>> CreateModelType([FromBody] CreateModelTypeRequest request)
    {
        var modelType = request.MapToModelType();
        await _modelTypeRepository.CreateAsync(modelType);
        var movieResponse = modelType.MapToResponse();
        // return CreatedAtAction(nameof(Get), new { id = movie.Id }, movieResponse);
        return Created();
    }
}

