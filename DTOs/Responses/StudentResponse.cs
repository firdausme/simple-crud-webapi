namespace SimpleCrudWebApi.DTOs.Responses;

public record StudentResponse(int Id, string Name, string Email, DateTime DateOfBirth);