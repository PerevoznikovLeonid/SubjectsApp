using System.Collections.ObjectModel;
using ReactiveUI.SourceGenerators;

namespace SubjectsApp.ViewModels;

public partial class SubjectsViewModel(ObservableCollection<string> sharedSubjects) : ViewModelBase
{
    public ObservableCollection<string> Subjects { get; } = sharedSubjects;

    [Reactive] private string _newSubjectName = string.Empty;

    [ReactiveCommand]
    private void AddSubject()
    {
        if (string.IsNullOrWhiteSpace(NewSubjectName)
            || Subjects.Contains(NewSubjectName))
            return;
        
        Subjects.Add(NewSubjectName);
        NewSubjectName = string.Empty;
    }

    [ReactiveCommand]
    private void RemoveSubject(string subject)
    {
        Subjects.Remove(subject);
    }
}