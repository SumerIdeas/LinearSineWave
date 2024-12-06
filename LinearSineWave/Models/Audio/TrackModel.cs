using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LinearSineWave.Models.Audio;

#pragma warning disable CS8618
public class TrackModel : ObservableValidator
{
    [Required]
    public long TrackIdx { get; set; }
    
    [Required]
    public long TrackKey { get; set; }
    
    [Required]
    public string LibraryGuid { get; set; }
    
    [Required]
    public string TrackTitle { get; set; }
    
    [Required]
    public string TrackArtist { get; set; }
    
    public string TrackAlbum { get; set; } = String.Empty;
    public string? TrackYear { get; set; }
    public int TrackNumber { get; set; } = 0;
    public string? GenreKey { get; set; }
    public string? TrackGenre { get; set; }
    public string? TrackName { get; set; }
    public string TrackPath { get; set; } = String.Empty;
    public string TrackExtension { get; set; } = String.Empty;
    public string? TrackComment { get; set; }
    public bool TrackHasBeenUpdated { get; set; } = false;
}