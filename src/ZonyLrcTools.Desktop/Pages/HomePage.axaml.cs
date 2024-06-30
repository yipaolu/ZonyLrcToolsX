using Avalonia;
using Avalonia.Controls;
using ZonyLrcTools.Desktop.ViewModels;

namespace ZonyLrcTools.Desktop.Pages;

public partial class HomePage : UserControl
{
    public HomePage()
    {
        InitializeComponent();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        
        if (DataContext is HomeViewModel vm)
        {
            vm.MaxProgress = 100;
            vm.DownloadProgress = 0;
        }
    }
}