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
    private readonly GlobalLyricsConfigOptions _config;

    public GlobalConfigurationViewModel(GlobalLyricsConfigOptions config)
    {
        _config = config;
        InitializeLineBreakComboBoxItem();

        IsOneLine = _config.IsOneLine;
        IsEnableTranslation = _config.IsEnableTranslation;
        IsSkipExistLyricFiles = _config.IsSkipExistLyricFiles;
        IsOnlyOutputTranslation = _config.IsOnlyOutputTranslation;

        this.WhenAnyValue(x => x.IsOneLine)
            .Subscribe(x => _config.IsOneLine = x);
        this.WhenAnyValue(x => x.IsEnableTranslation)
            .Subscribe(x => _config.IsEnableTranslation = x);
        this.WhenAnyValue(x => x.IsSkipExistLyricFiles)
            .Subscribe(x => _config.IsSkipExistLyricFiles = x);
        this.WhenAnyValue(x => x.IsOnlyOutputTranslation)
            .Subscribe(x => _config.IsOnlyOutputTranslation = x);
    }

    [Reactive] public bool IsOneLine { get; set; }

    [Reactive] public bool IsEnableTranslation { get; set; }

    [Reactive] public bool IsSkipExistLyricFiles { get; set; }

    [Reactive] public string FileEncoding { get; set; }

    [Reactive] public bool IsOnlyOutputTranslation { get; set; }

    private void InitializeLineBreakComboBoxItem()
    {
        LineBreakOptions =
        [
            new TextComboboxItem { Name = "Windows", Value = "\r\n" },
            new TextComboboxItem { Name = "Unix", Value = "\n" },
            new TextComboboxItem { Name = "Mac", Value = "\r" }
        ];
        SelectedLineBreak = LineBreakOptions.FirstOrDefault(x => x.Value == _config.LineBreak)
                            ?? LineBreakOptions.First();

        FileEncodingOptions = Encoding.GetEncodings()
            .Select(x => new TextComboboxItem { Name = x.DisplayName, Value = x.Name })
            .ToList();
        FileEncodingOptions.Insert(0, new TextComboboxItem { Name = "UTF-8-BOM", Value = "utf-8-bom" });
        SelectedFileEncoding = FileEncodingOptions.FirstOrDefault(x => x.Value == _config.FileEncoding)
                               ?? FileEncodingOptions.First();

        this.WhenAnyValue(x => x.SelectedLineBreak)
            .Subscribe(x => _config.LineBreak = x.Value);
        this.WhenAnyValue(x => x.SelectedFileEncoding)
            .Subscribe(x => _config.FileEncoding = x.Value);
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