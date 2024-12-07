using CommunityToolkit.Mvvm.ComponentModel;

namespace LinearSineWave.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly ArtistTrackViewModel _artistTrackPage = new();
    
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
    
    public ArtistTrackViewModel ArtistTrackPage => _artistTrackPage;
}