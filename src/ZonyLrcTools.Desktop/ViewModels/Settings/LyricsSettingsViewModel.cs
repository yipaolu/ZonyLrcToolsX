using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class LyricsSettingsViewModel : ViewModelBase
{
    private readonly GlobalOptions _globalOptions;

    public LyricsSettingsViewModel(GlobalOptions globalOptions)
    {
        _globalOptions = globalOptions;
        Config = new GlobalConfigurationViewModel(globalOptions.Provider.Lyric.Config);
        Plugin = new ObservableCollection<LyricsProviderViewModel>(
            globalOptions.Provider.Lyric.Plugin.Select(p => new LyricsProviderViewModel(p)));
        Tag = new TagInfoViewModel(globalOptions.Provider.Tag);
        BrowseBlockWordFileCommand = ReactiveCommand.Create(BrowseBlockWordFile);
    }

    public TagInfoViewModel Tag { get; }

    public ReactiveCommand<Unit, Unit> BrowseBlockWordFileCommand { get; }

    public GlobalConfigurationViewModel Config { get; }

    public ObservableCollection<LyricsProviderViewModel> Plugin { get; }

    private void BrowseBlockWordFile()
    {
        // Implement file browsing logic here
        // Update Tag.BlockWord.FilePath with the selected file path
    }
}