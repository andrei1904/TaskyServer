using Microsoft.EntityFrameworkCore;
using TS.Model.Entities;
using Task = TS.Model.Entities.Task;

namespace TS.Repository;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Task> Tasks { get; set; }

    public DbSet<Subtask> Subtasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<User>()
        //     .HasMany(user => user.Tasks)
        //     .WithOne()
        //     .HasForeignKey(x => x.UserId);

        // modelBuilder
        //     .Entity<Task>()
        //     .Property(t => t.Priority)
        //     .HasConversion(
        //         p => p.ToString(),
        //         p => (Priority)Enum.Parse(typeof(Priority), p)
        //     );
    }
}