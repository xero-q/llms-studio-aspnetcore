using LLMStudio.Data;
using LLMStudio.Data.Models;
using LLMStudio.Helpers;
using Microsoft.EntityFrameworkCore;

namespace LLMStudio.Repositories;

public class UserRepository:IUserRepository
{
    private readonly LLMDbContext _context;

    public UserRepository(LLMDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> CreateAsync(User user)
    {
        var hashedUser = new User
        {
            Id = user.Id,
            Username = user.Username,
            Password = PasswordHelper.HashPassword(user.Password)
        };
            
        _context.Users.Add(hashedUser);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
    
    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _context.Users.AnyAsync(u => u.Username == username);
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