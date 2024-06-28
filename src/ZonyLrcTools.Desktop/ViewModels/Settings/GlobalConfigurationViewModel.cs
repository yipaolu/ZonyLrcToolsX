using ZonyLrcTools.Common.Configuration;

namespace ZonyLrcTools.Desktop.ViewModels.Settings;

public class GlobalConfigurationViewModel : ViewModelBase
{
    private readonly GlobalLyricsConfigOptions _config;

    public GlobalConfigurationViewModel(GlobalLyricsConfigOptions config)
    {
        _config = config;
    }

    public bool IsOneLine
    {
        get => _config.IsOneLine;
        set
        {
            if (_config.IsOneLine != value)
            {
                _config.IsOneLine = value;
            }
        }
    }

    public string LineBreak
    {
        get => _config.LineBreak;
        set
        {
            if (_config.LineBreak != value)
            {
                _config.LineBreak = value;
            }
        }
    }

    public bool IsEnableTranslation
    {
        get => _config.IsEnableTranslation;
        set
        {
            if (_config.IsEnableTranslation != value)
            {
                _config.IsEnableTranslation = value;
            }
        }
    }

    public bool IsSkipExistLyricFiles
    {
        get => _config.IsSkipExistLyricFiles;
        set
        {
            if (_config.IsSkipExistLyricFiles != value)
            {
                _config.IsSkipExistLyricFiles = value;
            }
        }
    }

    public string FileEncoding
    {
        get => _config.FileEncoding;
        set
        {
            if (_config.FileEncoding != value)
            {
                _config.FileEncoding = value;
            }
        }
    }

    public bool IsOnlyOutputTranslation
    {
        get => _config.IsOnlyOutputTranslation;
        set
        {
            if (_config.IsOnlyOutputTranslation != value)
            {
                _config.IsOnlyOutputTranslation = value;
            }
        }
    }
}