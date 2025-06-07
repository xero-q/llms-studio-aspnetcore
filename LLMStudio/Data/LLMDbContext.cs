using LLMStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Thread = LLMStudio.Data.Models.Thread;

namespace LLMStudio.Data;

public class LLMDbContext:DbContext
{
    public LLMDbContext(DbContextOptions<LLMDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Thread>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("NOW()"); // Postgre
        
        modelBuilder.Entity<Prompt>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("NOW()"); // Postgre
        
        modelBuilder.Entity<Thread>()
            .HasOne(t => t.Model)
            .WithMany()
            .HasForeignKey(t => t.ModelId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Thread>()
            .HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict); 
        
        modelBuilder.Entity<Thread>()
            .HasOne(t => t.Model)
            .WithMany(m => m.Threads)
            .HasForeignKey(t => t.ModelId)
            .OnDelete(DeleteBehavior.Cascade); 

        // THREAD ↔ USER
        modelBuilder.Entity<Thread>()
            .HasOne(t => t.User)
            .WithMany(u => u.Threads)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    public DbSet<ModelType> ModelTypes { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Thread> Threads { get; set; }
    public DbSet<Prompt> Prompts { get; set; }
    public DbSet<User> Users { get; set; }
}