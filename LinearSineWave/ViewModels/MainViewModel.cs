using System;
using System.Xml.XPath;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LinearSineWave.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage;
    
    private readonly ArtistTrackViewModel _artistTrackPage = new();
    private readonly ConfigurationViewModel _configurationPage = new();

    public MainViewModel()
    {
        CurrentPage = _artistTrackPage;
    }
    
    
    public string? CurrentTrackName { get; set; }
    public string? CurrentTrackAlbum { get; set; }
    public string? CurrentTrackArtist { get; set; }
    public float TrackPosition { get; set; } = -1.0F;
    public float TrackLength { get; set; } = 0.0F;


    public string TrackPositionLabel
    {
        get => TrackPosition == -1 ? "00.00" : TrackPosition.ToString("00.00");
    }
    public string TrackLengthLabel
    {
        get => TrackLength.ToString("00.00");
    }


    [RelayCommand]
    private void NavigateToArtistTrackPage()
    {
        CurrentPage = _artistTrackPage;
    }
    
    [RelayCommand]
    private void NavigateToConfigurationPage()
    {
        CurrentPage = _configurationPage;
    }
}