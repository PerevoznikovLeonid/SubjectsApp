using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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