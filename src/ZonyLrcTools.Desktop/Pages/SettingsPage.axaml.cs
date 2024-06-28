using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ZonyLrcTools.Common.Configuration;
using ZonyLrcTools.Desktop.ViewModels;
using ZonyLrcTools.Desktop.ViewModels.Settings;

namespace ZonyLrcTools.Desktop.Pages;

public partial class SettingsPage : UserControl
{
    public SettingsPage()
    {
        InitializeComponent();
        DataContext = new LyricsSettingsViewModel(App.Current.Services.GetRequiredService<IOptions<GlobalOptions>>().Value);
    }
}