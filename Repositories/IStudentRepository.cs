using SimpleCrudWebApi.Entities;

namespace SimpleCrudWebApi.Repositories;

public interface IStudentRepository
{
    Task<List<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int id);
    
    Task<Student?> GetByEmailAsync(string email);
    Task AddAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(Student student);
}