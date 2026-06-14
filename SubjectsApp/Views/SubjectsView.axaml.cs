using Avalonia.Controls;
using SubjectsApp.ViewModels;

namespace SubjectsApp.Views;

public partial class SubjectsView : UserControl
{
    public SubjectsViewModel? ViewModel => DataContext as SubjectsViewModel;
    
    public SubjectsView()
    {
        InitializeComponent();
    }
}