using LLMStudio.Data.Models;

namespace LLMStudio.Repositories;

public interface IModelTypeRepository
{
    Task<bool> CreateAsync(ModelType modelType);
    
    Task<ModelType?> GetByIdAsync(int id);
   
    Task<IEnumerable<ModelType>> GetAllAsync();
    
    Task<bool> UpdateAsync(ModelType modelType);
    
    Task<bool> DeleteByIdAsync(int id);
}