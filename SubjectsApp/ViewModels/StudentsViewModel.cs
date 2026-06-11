using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using SubjectsApp.Models;

namespace SubjectsApp.ViewModels;

public partial class StudentsViewModel: ViewModelBase
{
    public ObservableCollection<Student> Students { get; } =
    [
        new() { FirstName = "Иван", LastName = "Петров" },
        new() { FirstName = "Мария", LastName = "Иванова" },
        new() { FirstName = "Алексей", LastName = "Смирнов" }
    ];
    
    [Reactive]
    private Student? _selectedStudent;

    [Reactive]
    private ObservableCollection<string> _studentSubjects = [];

    public ObservableCollection<string> AvailableSubjects { get; }

    public StudentsViewModel(ObservableCollection<string> allSubjects)
    {
        AvailableSubjects = allSubjects;

        this.WhenAnyValue(x => x.SelectedStudent)
            .Subscribe(student =>
            {
                StudentSubjects = student != null
                    ? new ObservableCollection<string>(student.Subjects)
                    : [];
            });
    }

    [ReactiveCommand]
    private void AddSubject(string subject)
    {
        if (SelectedStudent == null || string.IsNullOrWhiteSpace(subject)) return;

        if (SelectedStudent.Subjects.Contains(subject)) return;
        SelectedStudent.Subjects.Add(subject);
        StudentSubjects = new ObservableCollection<string>(SelectedStudent.Subjects);
    }
}