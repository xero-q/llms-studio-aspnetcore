using LLMStudio.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LLMStudio.Data;

public class LLMDbContext:DbContext
{
    public LLMDbContext(DbContextOptions<LLMDbContext> options) : base(options) {}
    
    public DbSet<ModelType> ModelTypes { get; set; }
    public DbSet<Model> Models { get; set; }
}