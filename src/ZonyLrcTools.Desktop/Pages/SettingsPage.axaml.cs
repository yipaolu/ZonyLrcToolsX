using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ZonyLrcTools.Common.Configuration;
using ZonyLrcTools.Desktop.Helpers;
using ZonyLrcTools.Desktop.ViewModels.Settings;

namespace ZonyLrcTools.Desktop.Pages;

public partial class SettingsPage : UserControl
{
    public SettingsPage()
    {
        InitializeComponent();
        DataContext = new LyricsSettingsViewModel(App.Current.Services.GetRequiredService<IOptions<GlobalOptions>>().Value);
    }

    private void OnGitHubClick(object? sender, RoutedEventArgs? eventArgs) => UrlHelper.OpenLink("https://github.com/real-zony/ZonyLrcToolsX");
}