using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ReactiveUI.Fody.Helpers;
using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class LyricsProviderViewModel : ViewModelBase
{
    public LyricsProviderViewModel(LyricsProviderOptions options)
    {
        var globalOptions = App.Current.Services.GetRequiredService<IOptions<GlobalOptions>>().Value;

        Name = options.Name;
        Priority = options.Priority;
        Depth = options.Depth;

        SubscribeToProperty(this, x => x.Priority, x => globalOptions.Provider.Lyric.GetLyricProviderOption(Name).Priority = x);
        SubscribeToProperty(this, x => x.Depth, x => globalOptions.Provider.Lyric.GetLyricProviderOption(Name).Depth = x);
    }

    public string Name { get; set; }

    [Reactive] public int Priority { get; set; }

    [Reactive] public int Depth { get; set; }
}

internal class NullToDefaultValueConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value != null ? System.Convert.ToDecimal(value) : 0;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is decimal dValue)
        {
            return System.Convert.ToInt32(dValue);
        }

        return BindingOperations.DoNothing;
    }
}