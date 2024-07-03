using ReactiveUI.Fody.Helpers;
using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class BlockWordViewModel : ViewModelBase
{
    public BlockWordViewModel(GlobalOptions options)
    {
        IsEnable = options.Provider.Tag.BlockWord.IsEnable;
        FilePath = options.Provider.Tag.BlockWord.FilePath;

        SubscribeToProperty(this, x => x.IsEnable, x => options.Provider.Tag.BlockWord.IsEnable = x);
        SubscribeToProperty(this, x => x.FilePath, x => options.Provider.Tag.BlockWord.FilePath = x!);
    }

    [Reactive] public bool IsEnable { get; set; }

    [Reactive] public string? FilePath { get; set; }
}