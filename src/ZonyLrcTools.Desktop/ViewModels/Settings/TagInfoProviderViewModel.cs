using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ReactiveUI.Fody.Helpers;
using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class TagInfoProviderViewModel : ViewModelBase
{
    public TagInfoProviderViewModel(TagInfoProviderOptions options)
    {
        var globalOptions = App.Current.Services.GetRequiredService<IOptions<GlobalOptions>>().Value;

        Name = options.Name;
        Priority = options.Priority;
        Extensions = options.Extensions == null ? [] : new ObservableCollection<ObservableKeyValuePair>(options.Extensions.Select(x => new ObservableKeyValuePair(x.Key, x.Value)));

        SubscribeToProperty(this, x => x.Priority, x => globalOptions.Provider.Tag.GetTagProviderOption(Name).Priority = x);
        SubscribeToProperty(this, x => x.Extensions, x => globalOptions.Provider.Tag.GetTagProviderOption(Name).Extensions = x.ToDictionary(pair => pair.Key, pair => pair.Value));
    }

    public string? Name { get; set; }

    [Reactive] public int Priority { get; set; }

    [Reactive] public ObservableCollection<ObservableKeyValuePair> Extensions { get; set; }
}

public class ObservableKeyValuePair : ViewModelBase
{
    [Reactive] public string Key { get; set; }

    [Reactive] public string Value { get; set; }

    public ObservableKeyValuePair(string key, string value)
    {
        Key = key;
        Value = value;
    }
}