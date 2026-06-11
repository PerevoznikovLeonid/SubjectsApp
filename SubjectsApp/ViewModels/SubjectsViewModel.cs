using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using ReactiveUI.SourceGenerators;
using SubjectsApp.Models;

namespace SubjectsApp.ViewModels;

public partial class SubjectsViewModel: ViewModelBase
{
    public ObservableCollection<string> AvailableSubjects { get; } = 
    [
        "Математика",
        "Физика",
        "История",
        "Химия"
    ];

    [Reactive] private ObservableCollection<string> _studentSubjects = [];

    private readonly IObservable<Student?> _selectedStudent;
    
    public SubjectsViewModel(IObservable<Student?> selectedStudent)
    {
        _selectedStudent = selectedStudent;
        
        _selectedStudent.Subscribe(student =>
        {
            StudentSubjects = student != null
                ? new ObservableCollection<string>(student.Subjects)
                : [];
        });
    }

    [ReactiveCommand]
    private void AddSubject(string subject)
    {
        Student? currentStudent = null;
        _selectedStudent.Take(1).Subscribe(s => currentStudent = s);

        if (currentStudent == null || string.IsNullOrWhiteSpace(subject)) return;
        if (currentStudent.Subjects.Contains(subject)) return;

        currentStudent.Subjects.Add(subject);
        StudentSubjects = new ObservableCollection<string>(currentStudent.Subjects);
    }
}