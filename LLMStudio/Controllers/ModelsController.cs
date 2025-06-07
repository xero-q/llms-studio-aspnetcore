using LLMStudio.Contracts.Requests;
using LLMStudio.Repositories;
using LLMStudio.Data.Models;
using LLMStudio.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LLMStudio.Controllers;

[ApiController]
public class ModelsController(IModelTypeRepository modelTypeRepository, IModelRepository modelRepository)
    : ControllerBase
{
    [HttpPost(ApiEndpoints.Models.Create)]
    public async Task<ActionResult<Model>> CreateAsync([FromBody] CreateModelRequest request)
    {
        // Verify ModelType exists
        var modelType = await modelTypeRepository.GetByIdAsync(request.ModelTypeId);

        if (modelType == null)
        {
            return BadRequest(new {error=ErrorMessages.ModelTypeNotFound});
        }
        
        var model = request.MapToModel();
        await modelRepository.CreateAsync(model);
        var modelResponse = model.MapToResponse();
        return Created();
        //TODO return CreatedAtAction(nameof(GetModelType), new { id = modelType.Id }, modelTypeResponse);
    }
}