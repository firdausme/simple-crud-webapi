using Microsoft.EntityFrameworkCore;
using SimpleCrudWebApi.Data;
using SimpleCrudWebApi.Entities;

namespace SimpleCrudWebApi.Repositories;

public class StudentRepository(AppDbContext context) : IStudentRepository
{
    public async Task<List<Student>> GetAllAsync()
    {
        return await context.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await context.Students.FindAsync(id);
    }

    public async Task<Student?> GetByEmailAsync(string email)
    {
        return await context.Students.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task AddAsync(Student student)
    {
        await context.Students.AddAsync(student);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        context.Students.Update(student);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Student student)
    {
        context.Students.Remove(student);
        await context.SaveChangesAsync();
    }
}