using System.Collections.ObjectModel;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace SubjectsApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<string> AllSubjects { get; } =
    [
        "Математика",
        "Физика",
        "История",
        "Программирование"
    ];

    public StudentsViewModel StudentsVm { get; }
    public SubjectsViewModel SubjectsVm { get; }

    [Reactive] private ViewItem _currentView;

    public ObservableCollection<ViewItem> Views { get; }

    public MainWindowViewModel()
    {
        StudentsVm = new StudentsViewModel(AllSubjects);
        SubjectsVm = new SubjectsViewModel(AllSubjects);

        Views =
        [
            new ViewItem { Name = "Студенты", ViewModel = StudentsVm },
            new ViewItem { Name = "Предметы", ViewModel = SubjectsVm }
        ];

        CurrentView = Views[0];
    }
}

public class ViewItem
{
    public required string Name { get; init; }
    public required ReactiveObject ViewModel { get; init; }
}