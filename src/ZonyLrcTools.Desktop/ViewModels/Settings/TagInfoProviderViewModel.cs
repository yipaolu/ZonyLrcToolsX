using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class TagInfoProviderViewModel : ViewModelBase
{
    private readonly TagInfoProviderOptions _options;

    public TagInfoProviderViewModel(TagInfoProviderOptions options)
    {
        _options = options;
        Extensions = new ObservableCollection<KeyValuePair<string, string>>(options.Extensions ?? new Dictionary<string, string>());
    }

    public string Name
    {
        get => _options.Name;
        set
        {
            if (_options.Name != value)
            {
                _options.Name = value;
            }
        }
    }

    public int Priority
    {
        get => _options.Priority;
        set
        {
            if (_options.Priority != value)
            {
                _options.Priority = value;
            }
        }
    }

    public ObservableCollection<KeyValuePair<string, string>> Extensions { get; }
}