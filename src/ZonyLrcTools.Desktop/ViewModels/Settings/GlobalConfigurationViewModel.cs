using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class GlobalConfigurationViewModel : ViewModelBase
{
    public GlobalConfigurationViewModel(GlobalOptions config)
    {
        var globalConfig = config.Provider.Lyric.Config;

        InitializeLineBreakComboBoxItem(globalConfig);

        IsOneLine = globalConfig.IsOneLine;
        IsEnableTranslation = globalConfig.IsEnableTranslation;
        IsSkipExistLyricFiles = globalConfig.IsSkipExistLyricFiles;
        IsOnlyOutputTranslation = globalConfig.IsOnlyOutputTranslation;

        this.WhenAnyValue(x => x.IsOneLine)
            .Subscribe(x => globalConfig.IsOneLine = x);
        this.WhenAnyValue(x => x.IsEnableTranslation)
            .Subscribe(x => globalConfig.IsEnableTranslation = x);
        this.WhenAnyValue(x => x.IsSkipExistLyricFiles)
            .Subscribe(x => globalConfig.IsSkipExistLyricFiles = x);
        this.WhenAnyValue(x => x.IsOnlyOutputTranslation)
            .Subscribe(x => globalConfig.IsOnlyOutputTranslation = x);
    }

    [Reactive] public bool IsOneLine { get; set; }

    [Reactive] public bool IsEnableTranslation { get; set; }

    [Reactive] public bool IsSkipExistLyricFiles { get; set; }

    [Reactive] public bool IsOnlyOutputTranslation { get; set; }

    private void InitializeLineBreakComboBoxItem(GlobalLyricsConfigOptions config)
    {
        LineBreakOptions =
        [
            new TextComboboxItem { Name = "Windows", Value = "\r\n" },
            new TextComboboxItem { Name = "Unix", Value = "\n" },
            new TextComboboxItem { Name = "Mac", Value = "\r" }
        ];
        SelectedLineBreak = LineBreakOptions.FirstOrDefault(x => x.Value == config.LineBreak)
                            ?? LineBreakOptions.First();

        FileEncodingOptions = Encoding.GetEncodings()
            .Select(x => new TextComboboxItem { Name = x.DisplayName, Value = x.Name })
            .ToList();
        FileEncodingOptions.Insert(0, new TextComboboxItem { Name = "UTF-8-BOM", Value = "utf-8-bom" });
        SelectedFileEncoding = FileEncodingOptions.FirstOrDefault(x => x.Value == config.FileEncoding)
                               ?? FileEncodingOptions.First();

        this.WhenAnyValue(x => x.SelectedLineBreak)
            .Subscribe(x => config.LineBreak = x.Value);
        this.WhenAnyValue(x => x.SelectedFileEncoding)
            .Subscribe(x => config.FileEncoding = x.Value);
    }

    public List<TextComboboxItem> LineBreakOptions { get; private set; }

    [Reactive] public TextComboboxItem SelectedLineBreak { get; set; }

    public List<TextComboboxItem> FileEncodingOptions { get; private set; }

    [Reactive] public TextComboboxItem SelectedFileEncoding { get; set; }

    public class TextComboboxItem
    {
        public string Name { get; set; } = default!;
        public string Value { get; set; } = default!;
    }
}