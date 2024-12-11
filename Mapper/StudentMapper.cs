using AutoMapper;
using SimpleCrudWebApi.DTOs.Requests;
using SimpleCrudWebApi.DTOs.Responses;
using SimpleCrudWebApi.Entities;

namespace SimpleCrudWebApi.Mapper;

public class StudentMapper : Profile
{

    public StudentMapper()
    {
        CreateMap<Student, StudentRequest>();
        CreateMap<Student, StudentResponse>();

        CreateMap<StudentRequest, Student>();
        CreateMap<StudentResponse, Student>();
    }

}