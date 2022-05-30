using Microsoft.EntityFrameworkCore;
using TS.Model.Entities;

namespace TS.Repository;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}