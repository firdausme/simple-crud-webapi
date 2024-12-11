using Microsoft.EntityFrameworkCore;
using SimpleCrudWebApi.Extensions;
using SimpleCrudWebApi.Entities;

namespace SimpleCrudWebApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.ConfigureModels();
        modelBuilder.SeedData();
    }
}