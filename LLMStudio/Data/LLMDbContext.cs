using LLMStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Thread = LLMStudio.Data.Models.Thread;

namespace LLMStudio.Data;

public class LLMDbContext:DbContext
{
    public LLMDbContext(DbContextOptions<LLMDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Thread>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("GETDATE()"); // SQL Server
    }
    
    public DbSet<ModelType> ModelTypes { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Thread> Threads { get; set; }
}