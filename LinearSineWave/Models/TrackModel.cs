using System;

namespace LinearSineWave.Models;

public class TrackModel
{
    public long TrackIdx { get; set; }
    public long TrackKey { get; set; }
    public string LibraryGuid { get; set; } = String.Empty;
    public string TrackTitle { get; set; } = String.Empty;
    public string TrackArtist { get; set; } = String.Empty;
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