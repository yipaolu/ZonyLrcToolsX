using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class BlockWordViewModel : ViewModelBase
{
    private readonly BlockWordOptions _options;

    public BlockWordViewModel(BlockWordOptions options)
    {
        _options = options;
    }

    public bool IsEnable
    {
        get => _options.IsEnable;
        set
        {
            if (_options.IsEnable != value)
            {
                _options.IsEnable = value;
            }
        }
    }

    public string FilePath
    {
        get => _options.FilePath;
        set
        {
            if (_options.FilePath != value)
            {
                _options.FilePath = value;
            }
        }
    }
}