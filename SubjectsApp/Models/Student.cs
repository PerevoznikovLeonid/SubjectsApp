using System.Collections.Generic;

namespace SubjectsApp.Models;

public class Student
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public List<string> Subjects { get; } = [];
}