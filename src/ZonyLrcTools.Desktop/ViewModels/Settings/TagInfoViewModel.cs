using System.Collections.ObjectModel;
using System.Linq;
using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class TagInfoViewModel : ViewModelBase
{
    public TagInfoViewModel(GlobalOptions options)
    {
        BlockWord = new BlockWordViewModel(options);
        TagInfoProviders = new ObservableCollection<TagInfoProviderViewModel>(options.Provider.Tag.Plugin.Select(p => new TagInfoProviderViewModel(p)));
    }

    public BlockWordViewModel BlockWord { get; }

    public ObservableCollection<TagInfoProviderViewModel> TagInfoProviders { get; }
}