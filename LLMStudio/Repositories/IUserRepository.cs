using LLMStudio.Data.Models;

namespace LLMStudio.Repositories;

public interface IUserRepository
{
    Task<bool> CreateAsync(User user);
    
    Task<User?> GetByIdAsync(int id);
   
    Task<IEnumerable<User>> GetAllAsync();
    
    Task<bool> UpdateAsync(User user);
    
    Task<bool> DeleteByIdAsync(int id);
}