using Avalonia.Controls;
using ZonyLrcTools.Desktop.ViewModels;

namespace ZonyLrcTools.Desktop.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = new HomeViewModel();
        InitializeComponent();
    }
}