using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI.Fody.Helpers;
using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class TagInfoProviderViewModel : ViewModelBase
{
    public TagInfoProviderViewModel(TagInfoProviderOptions options)
    {
        Name = options.Name;
        Priority = options.Priority;
        Extensions = new ObservableCollection<KeyValuePair<string, string>>(options.Extensions ?? new Dictionary<string, string>());
    }

    public string? Name { get; set; }

    [Reactive] public int Priority { get; set; }

    public ObservableCollection<KeyValuePair<string, string>> Extensions { get; }
}