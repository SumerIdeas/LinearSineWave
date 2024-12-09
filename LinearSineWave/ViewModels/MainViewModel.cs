using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LinearSineWave.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly ArtistTrackViewModel _artistTrackViewModel = new();
    private readonly ConfigurationViewModel _configurationViewModel = new();

    [ObservableProperty] private ViewModelBase _currentPageView;

    public string? CurrentTrackName { get; set; }
    public string? CurrentTrackAlbum { get; set; }
    public string? CurrentTrackArtist { get; set; }
    public float TrackPosition { get; set; } = -1.0F;
    public float TrackLength { get; set; } = 0.0F;

    public MainViewModel()
    {
        CurrentPageView = _artistTrackViewModel;
    }
    
    
    
    public string TrackPositionLabel
    {
        get => TrackPosition == -1 ? "00.00" : TrackPosition.ToString("00.00");
    }
    public string TrackLengthLabel
    {
        get => TrackLength.ToString("00.00");
    }

    [RelayCommand]
    public void SwitchCurrentPage(string pageName)
    {
        CurrentPageView = pageName switch
        {
            "ArtistTrack" => _artistTrackViewModel,
            "Configuration" => _configurationViewModel,
            _ => throw new ArgumentException($"unknown page name {pageName}")
        };
    }
}