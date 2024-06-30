using Avalonia;
using Avalonia.Controls.Primitives;
using FluentIcons.Common;
using ZonyLrcTools.Desktop.ViewModels;

namespace ZonyLrcTools.Desktop.Controls;

public class DownloadStatusControl : TemplatedControl
{
    public static readonly StyledProperty<DownloadStatus> StatusProperty =
        AvaloniaProperty.Register<DownloadStatusControl, DownloadStatus>(nameof(Status));

    public static readonly StyledProperty<Symbol> SymbolProperty =
        AvaloniaProperty.Register<DownloadStatusControl, Symbol>(nameof(Symbol));

    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<DownloadStatusControl, string>(nameof(Text));

    public DownloadStatus Status
    {
        get => GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    public Symbol Symbol
    {
        get => GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}