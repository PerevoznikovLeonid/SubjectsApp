using Avalonia.Controls;
using SubjectsApp.ViewModels;

namespace SubjectsApp.Views;

public partial class StudentsView : UserControl
{
    public StudentsViewModel? ViewModel => DataContext as StudentsViewModel;
    
    public StudentsView()
    {
        InitializeComponent();
    }
}