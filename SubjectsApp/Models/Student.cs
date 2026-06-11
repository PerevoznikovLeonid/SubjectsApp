using System;
using System.Collections.Generic;

namespace SubjectsApp.Models;

public class Student
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public List<string> Subjects { get; set; } = [];
}