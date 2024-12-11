using SimpleCrudWebApi.DTOs.Requests;
using SimpleCrudWebApi.DTOs.Responses;

namespace SimpleCrudWebApi.Services;

public interface IStudentService
{
    Task<List<StudentResponse>> GetAll();
    Task<StudentResponse> GetById(int id);
    
    Task<StudentResponse?> GetByEmail(string email);
    
    Task Add(StudentRequest request);
    Task Update(StudentRequest request);
    Task Delete(int id);
}