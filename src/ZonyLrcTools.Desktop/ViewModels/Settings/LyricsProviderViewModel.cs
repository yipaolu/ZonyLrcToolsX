using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class LyricsProviderViewModel : ViewModelBase
{
    private readonly LyricsProviderOptions _options;

    public LyricsProviderViewModel(LyricsProviderOptions options)
    {
        _options = options;
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

    public int Depth
    {
        get => _options.Depth;
        set
        {
            if (_options.Depth != value)
            {
                _options.Depth = value;
            }
        }
    }
}