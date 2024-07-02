using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using ReactiveUI;
using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class SettingsViewModel : ViewModelBase
{
    public SettingsViewModel(GlobalOptions globalOptions)
    {
        Config = new GlobalConfigurationViewModel(globalOptions);
        LyricsProviders = new ObservableCollection<LyricsProviderViewModel>(globalOptions.Provider.Lyric.Plugin.Select(p => new LyricsProviderViewModel(p)));
        Tag = new TagInfoViewModel(globalOptions);
        BrowseBlockWordFileCommand = ReactiveCommand.CreateFromTask<Window>(BrowseBlockWordFile);
    }

    public static string Version => typeof(Program).Assembly.GetName().Version!.ToString();

    public TagInfoViewModel Tag { get; }

    public ReactiveCommand<Window, Unit> BrowseBlockWordFileCommand { get; }

    public GlobalConfigurationViewModel Config { get; }

    public ObservableCollection<LyricsProviderViewModel> LyricsProviders { get; }

    private async Task BrowseBlockWordFile(Window parentWindow)
    {
        var storage = parentWindow.StorageProvider;
        if (storage.CanOpen)
        {
            var options = new FilePickerOpenOptions
            {
                AllowMultiple = false,
                FileTypeFilter = new[]
                {
                    new FilePickerFileType("JSON")
                    {
                        Patterns = new[] { "*.json" }
                    }
                }
            };

            var files = await storage.OpenFilePickerAsync(options);
            if (files.Count > 0)
            {
                Tag.BlockWord.FilePath = files[0].Path.LocalPath;
            }
        }
    }
}