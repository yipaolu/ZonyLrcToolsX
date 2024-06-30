using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using ZonyLrcTools.Common;

namespace ZonyLrcTools.Desktop.ViewModels;

public class HomeViewModel : ViewModelBase
{
    private ObservableCollection<SongInfoViewModel> _songs = new();

    public ObservableCollection<SongInfoViewModel> Songs
    {
        get => _songs;
        set => this.RaiseAndSetIfChanged(ref _songs, value);
    }

    private int _downloadProgress;

    public int DownloadProgress
    {
        get => _downloadProgress;
        set => this.RaiseAndSetIfChanged(ref _downloadProgress, value);
    }

    private int _maxProgress;

    public int MaxProgress
    {
        get => _maxProgress;
        set => this.RaiseAndSetIfChanged(ref _maxProgress, value);
    }
}

public class SongInfoViewModel : ReactiveObject
{
    public SongInfoViewModel(MusicInfo info)
    {
        _info = info;
        DownloadStatus = DownloadStatus.NotStarted;

        this.WhenAnyValue(x => x.Info)
            .Subscribe(_ =>
            {
                this.RaisePropertyChanged(nameof(SongName));
                this.RaisePropertyChanged(nameof(ArtistName));
                this.RaisePropertyChanged(nameof(FilePath));
            });
    }

    private MusicInfo _info;

    public MusicInfo Info
    {
        get => _info;
        set => this.RaiseAndSetIfChanged(ref _info, value);
    }

    public string SongName => Info.Name;
    public string ArtistName => Info.Artist;
    public string FilePath => Info.FilePath;

    private DownloadStatus _downloadStatus;

    public DownloadStatus DownloadStatus
    {
        get => _downloadStatus;
        set => this.RaiseAndSetIfChanged(ref _downloadStatus, value);
    }
}

public enum DownloadStatus
{
    NotStarted = 1,
    Completed,
    Failed
}