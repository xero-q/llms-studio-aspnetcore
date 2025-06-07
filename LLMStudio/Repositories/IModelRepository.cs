using LLMStudio.Data.Models;

namespace LLMStudio.Repositories;

public interface IModelRepository
{
    Task<bool> CreateAsync(Model model);
    
    Task<Model?> GetByIdAsync(int id);
   
    Task<IEnumerable<Model>> GetAllAsync();
    
    Task<bool> UpdateAsync(Model modelType);
    
    Task<bool> DeleteByIdAsync(int id);
}