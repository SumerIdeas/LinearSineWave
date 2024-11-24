﻿using CommunityToolkit.Mvvm.ComponentModel;
 
namespace LinearSineWave.ViewModels;

public partial class MainViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

    
    [ObservableProperty] private string _applicationName = "LinearSineWave";
    
    public string? CurrentTrackName { get; set; }
    public string? CurrentTrackAlbum { get; set; }
    public string? CurrentTrackArtist { get; set; }
    public float TrackPosition { get; set; } = -1.0F;
    public float TrackLength { get; set; } = 0.0F;

    public int MainTabSelectedIndex { get; set; } = 0;

    public string TrackPositionLabel
    {
        get => TrackPosition == -1 ? "00.00" : TrackPosition.ToString("00.00");
    }
    public string TrackLengthLabel
    {
        get => TrackLength.ToString("00.00");
    }
}