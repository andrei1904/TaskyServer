using Microsoft.EntityFrameworkCore;
using TS.Model.Entities;
using Task = TS.Model.Entities.Task;

namespace TS.Repository;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Task> Tasks { get; set; }

    public DbSet<Subtask> Subtasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>()
            .HasOne(n => n.User)
            .WithMany(n => n.Tasks);
    }
}