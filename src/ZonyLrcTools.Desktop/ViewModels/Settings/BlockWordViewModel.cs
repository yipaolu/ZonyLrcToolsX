using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class BlockWordViewModel : ViewModelBase
{
    public BlockWordViewModel(GlobalOptions options)
    {
        IsEnable = options.Provider.Tag.BlockWord.IsEnable;
        FilePath = options.Provider.Tag.BlockWord.FilePath;

        this.WhenAnyValue(x => x.IsEnable, x => x.FilePath)
            .Subscribe(_ =>
            {
                options.Provider.Tag.BlockWord.IsEnable = IsEnable;
                options.Provider.Tag.BlockWord.FilePath = FilePath;
            });
    }

    [Reactive] public bool IsEnable { get; set; }

    [Reactive] public string? FilePath { get; set; }
}