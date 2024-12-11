namespace SimpleCrudWebApi.DTOs.Requests;

public record StudentRequest(string Name, string Email, DateTime DateOfBirth);