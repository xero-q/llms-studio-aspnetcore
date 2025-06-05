using LLMStudio.Data.Models;

namespace LLMStudio.Repositories;

public class UserRepository:IUserRepository
{
    public async Task<bool> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}