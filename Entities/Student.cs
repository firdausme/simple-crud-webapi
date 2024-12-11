namespace SimpleCrudWebApi.Entities;

public class Student()
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }

    public override string ToString()
    {
        return @$"Id: {Id}, Name: {Name}, Email: {Email}, DateOfBirth: {DateOfBirth?.ToString("dd-MM-yyyy")}";
    }
}