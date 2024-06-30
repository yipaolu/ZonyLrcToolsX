using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using DynamicData;
using FluentAvalonia.UI.Controls;
using Microsoft.Extensions.DependencyInjection;
using ZonyLrcTools.Common;
using ZonyLrcTools.Common.Lyrics;
using ZonyLrcTools.Desktop.Pages;
using ZonyLrcTools.Desktop.ViewModels;

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
        if (_downloadButton != null) _downloadButton.Click += OnDownloadButtonClick;
    }

    private async void OnDownloadButtonClick(object? sender, RoutedEventArgs e)
    {
        var downloader = App.Current.Services.GetRequiredService<ILyricsDownloader>();
        if (DataContext is HomeViewModel vm)
        {
            var needDownloadMusicInfos = vm.Songs
                .Where(x => x.DownloadStatus == DownloadStatus.NotStarted)
                .Select(x => x.Info)
                .ToList();

            vm.DownloadProgress = 0;
            vm.MaxProgress = needDownloadMusicInfos.Count;

            await downloader.DownloadAsync(needDownloadMusicInfos, callback: info =>
            {
                var song = vm.Songs.FirstOrDefault(x => x.Info == info);
                if (song != null)
                {
                    song.DownloadStatus = DownloadStatus.Completed;
                }
                
                vm.DownloadProgress++;
                return Task.CompletedTask;
            });
        }
    }

    private async void OnOpenFolderButtonClick(object? sender, RoutedEventArgs e)
    {
        var storage = _window?.StorageProvider;
        var musicInfoLoader = App.Current.Services.GetRequiredService<IMusicInfoLoader>();

        if (storage?.CanOpen == true && DataContext is HomeViewModel vm)
        {
            var options = new FolderPickerOpenOptions
            {
                SuggestedStartLocation = await storage.TryGetWellKnownFolderAsync(WellKnownFolder.Music)
            };
            var folders = await storage.OpenFolderPickerAsync(options);
            if (folders.Count == 0) return;
            var folderPath = folders[0].Path.LocalPath;
            var musicInfos = await musicInfoLoader.LoadAsync(folderPath);

            vm.Songs.Clear();
            vm.Songs.AddRange(musicInfos.Select(x => new SongInfoViewModel(x!)));
        }
    }

    private void OnSettingsButtonClick(object? sender, RoutedEventArgs e)
    {
        if (_frameView?.CurrentSourcePageType != typeof(SettingsPage))
            _frameView?.Navigate(typeof(SettingsPage));
    }
}