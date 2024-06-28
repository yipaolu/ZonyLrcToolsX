using System.Collections.ObjectModel;
using ReactiveUI;

namespace ZonyLrcTools.Desktop.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public ObservableCollection<SongInfo> Songs { get; } = [];

    private double _downloadProgress;

    public double DownloadProgress
    {
        get => _downloadProgress;
        set => this.RaiseAndSetIfChanged(ref _downloadProgress, value);
    }
}

public class SongInfo
{
    public string SongName { get; set; }
    public string ArtistName { get; set; }
    public string FilePath { get; set; }
    public string DownloadStatus { get; set; }
}