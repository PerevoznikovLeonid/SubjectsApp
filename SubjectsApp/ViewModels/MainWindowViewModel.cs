using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace SubjectsApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public StudentsViewModel Students { get; }
    public SubjectsViewModel Subjects { get; }

    [Reactive]
    private ViewModelBase _currentView;

    public MainWindowViewModel()
    {
        Students = new StudentsViewModel();
        
        Subjects = new SubjectsViewModel(
            Students.WhenAnyValue(x => x.SelectedStudent));
        
        CurrentView = Students;
    }
}