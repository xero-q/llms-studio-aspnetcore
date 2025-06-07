using FluentValidation;
using LLMStudio.Data;
using LLMStudio.Data.Models;

namespace LLMStudio.Repositories;

public class ModelRepository:IModelRepository
{
    private readonly LLMDbContext _context;
    private readonly IValidator<Model> _validator;

    public ModelRepository(LLMDbContext context, IValidator<Model> validator)
    {
        _context = context;
        _validator = validator;
    }
    
    public async Task<bool> CreateAsync(Model model)
    {
        await _validator.ValidateAndThrowAsync(model);
        _context.Models.Add(model);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Model?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Model>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(Model modelType)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}