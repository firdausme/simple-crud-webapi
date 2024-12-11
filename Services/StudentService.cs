using AutoMapper;
using SimpleCrudWebApi.DTOs.Requests;
using SimpleCrudWebApi.DTOs.Responses;
using SimpleCrudWebApi.Entities;
using SimpleCrudWebApi.Exceptions;
using SimpleCrudWebApi.Repositories;

namespace SimpleCrudWebApi.Services;

public class StudentService(IStudentRepository repository, IMapper mapper) : IStudentService
{
    public async Task<List<StudentResponse>> GetAll()
    {
        return mapper.Map<List<StudentResponse>>(
            await repository.GetAllAsync()
        );
    }

    public async Task<StudentResponse> GetById(int id)
    {
        var student = await repository.GetByIdAsync(id);
        if (student == null) throw new ResourceNotFoundException("Student not found");

        return mapper.Map<StudentResponse>(student);
    }

    public async Task<StudentResponse?> GetByEmail(string email)
    {
        var student = await repository.GetByEmailAsync(email);
        if (student == null) throw new ResourceNotFoundException("Student not found");

        return mapper.Map<StudentResponse>(student);
    }

    public async Task Add(StudentRequest request)
    {
        var student = await repository.GetByEmailAsync(request.Email);
        if (student != null) throw new ConflictException($"A student with email {request.Email} already exists");

        await repository.AddAsync(
            mapper.Map<Student>(request)
        );
    }

    public async Task Update(StudentRequest request)
    {
        var updateStudent = await repository.GetByEmailAsync(request.Email);
        if (updateStudent == null) throw new ResourceNotFoundException("Student not found");

        await repository.UpdateAsync(
            mapper.Map(request, updateStudent)
        );
    }

    public async Task Delete(int id)
    {
        var student = await repository.GetByIdAsync(id);
        if (student == null) throw new ResourceNotFoundException("Student not found");

        await repository.DeleteAsync(
            mapper.Map<Student>(student)
        );
    }
}