using LLMStudio;
using LLMStudio.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using LLMStudio.Data.Models;
using LLMStudio.Mappings;
using LLMStudio.Repositories;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Authorize]
public class ModelTypesController(IModelTypeRepository modelTypeRepository) : ControllerBase
{
    [HttpPost(ApiEndpoints.ModelTypes.Create)]
    public async Task<IActionResult> Create([FromBody] CreateModelTypeRequest request)
    {
        var modelType = request.MapToModelType();
        await modelTypeRepository.CreateAsync(modelType);
        var modelTypeResponse = modelType.MapToResponse();
        return CreatedAtAction(nameof(Get), new { id = modelType.Id }, modelTypeResponse);
    }

    [HttpGet(ApiEndpoints.ModelTypes.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var modelTypes = await modelTypeRepository.GetAllAsync();
        var response = modelTypes.MapToResponse();
        
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.ModelTypes.Get)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var modelType = await modelTypeRepository.GetByIdAsync(id);

        if (modelType == null)
        {
            return NotFound();
        }
        
        var response = modelType.MapToResponse();
        
        return Ok(response);
    }
}

