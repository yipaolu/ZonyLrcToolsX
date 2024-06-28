using System.Collections.ObjectModel;
using System.Linq;
using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class TagInfoViewModel : ViewModelBase
{
    private readonly TagInfoOptions _options;

    public TagInfoViewModel(TagInfoOptions options)
    {
        _options = options;
        BlockWord = new BlockWordViewModel(options.BlockWord);
        Plugin = new ObservableCollection<TagInfoProviderViewModel>(
            options.Plugin.Select(p => new TagInfoProviderViewModel(p)));
    }

    public BlockWordViewModel BlockWord { get; }
    public ObservableCollection<TagInfoProviderViewModel> Plugin { get; }
}