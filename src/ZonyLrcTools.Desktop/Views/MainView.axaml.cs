using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using FluentAvalonia.UI.Controls;
using ZonyLrcTools.Desktop.Pages;

namespace ZonyLrcTools.Desktop.Views;

public partial class MainView : UserControl
{
    private Window? _window;

    private Frame? _frameView;
    private Button? _settingsButton;
    private Button? _openFolderButton;
    private Button? _downloadButton;

    public MainView()
    {
        InitializeComponent();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        _window = e.Root as Window;

        _frameView = this.FindControl<Frame>("FrameView");
        _frameView?.Navigate(typeof(HomePage));

        _settingsButton = this.FindControl<Button>("SettingsButton");
        if (_settingsButton != null) _settingsButton.Click += OnSettingsButtonClick;

        _openFolderButton = this.FindControl<Button>("OpenFolderButton");
        if (_openFolderButton != null) _openFolderButton.Click += OnOpenFolderButtonClick;
        _downloadButton = this.FindControl<Button>("DownloadButton");
    }

    private async void OnOpenFolderButtonClick(object? sender, RoutedEventArgs e)
    {
        var storage = _window?.StorageProvider;
        if (storage?.CanOpen == true)
        {
            var options = new FolderPickerOpenOptions
            {
                SuggestedStartLocation = await storage.TryGetWellKnownFolderAsync(WellKnownFolder.Music)
            };
            var folders = await storage.OpenFolderPickerAsync(options);
            var folderPath = folders[0].Path;
        }
    }

    private void OnSettingsButtonClick(object? sender, RoutedEventArgs e)
    {
        if (_frameView?.CurrentSourcePageType != typeof(SettingsPage))
            _frameView?.Navigate(typeof(SettingsPage));
    }
}