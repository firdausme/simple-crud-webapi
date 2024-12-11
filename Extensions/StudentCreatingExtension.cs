using Microsoft.EntityFrameworkCore;
using SimpleCrudWebApi.Entities;

namespace SimpleCrudWebApi.Extensions;

public static class StudentCreatingExtension
{
    public static void ConfigureModels(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(student =>
        {
            student.ToTable("Students");
            student.HasKey(s => s.Id);
            student.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnType("int(11)");
            student.Property(s => s.Name).IsRequired().HasMaxLength(150);
            student.Property(s => s.Email).IsRequired().HasMaxLength(150);
            student.Property(s => s.DateOfBirth);
        });
    }

    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, Name = "Adi", Email = "adi@gmail.com", DateOfBirth = new DateTime(1980,1,1),},
            new Student { Id = 2, Name = "Budi", Email = "budi@gmail.com", DateOfBirth = new DateTime(1982,5,30),},
            new Student { Id = 3, Name = "Cyntia", Email = "cyntia@gmail.com", DateOfBirth = new DateTime(1983,12,15),},
            new Student { Id = 4, Name = "Danang", Email = "danang@gmail.com", DateOfBirth = new DateTime(1990,4,29),}
        );
    }
}