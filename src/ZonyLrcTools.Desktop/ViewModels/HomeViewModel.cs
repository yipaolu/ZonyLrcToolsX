using System.Collections.ObjectModel;
using ReactiveUI;
using ZonyLrcTools.Common;

namespace ZonyLrcTools.Desktop.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public ObservableCollection<SongInfoViewModel> Songs { get; } = [];

    private double _downloadProgress;

    public double DownloadProgress
    {
        get => _downloadProgress;
        set => this.RaiseAndSetIfChanged(ref _downloadProgress, value);
    }
}

public class SongInfoViewModel(MusicInfo info)
{
    private MusicInfo Info { get; } = info;

    public string SongName => Info.Name;
    public string ArtistName => Info.Artist;
    public string FilePath => Info.FilePath;

    public DownloadStatus DownloadStatus { get; set; } = DownloadStatus.NotStarted;
}

public enum DownloadStatus
{
    NotStarted = 1,
    Completed,
    Failed
}