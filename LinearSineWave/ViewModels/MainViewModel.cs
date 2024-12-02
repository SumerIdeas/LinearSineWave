using System;
using System.Xml.XPath;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LinearSineWave.Data;
using LinearSineWave.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace LinearSineWave.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private PageViewModel _currentPage;
    private readonly PageFactory _pageFactory;
    private readonly ArtistTrackViewModel _artistTrackPage = new();
    
    public MainViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;
        CurrentPage = _artistTrackPage;
    }

    public bool ArtistTrackIsActive => CurrentPage.PageName == ApplicationPages.ArtistTrack;
    public bool ConfigurationIsActive => CurrentPage.PageName == ApplicationPages.Configuration;
    
    
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
    private void ShowArtistTrackPage() => CurrentPage = _artistTrackPage;
    
    [RelayCommand]
    private void ShowConfigurationPage() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPages.Configuration);
}