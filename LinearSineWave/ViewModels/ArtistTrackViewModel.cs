using System.Collections.Generic;
using System.Collections.ObjectModel;
using LinearSineWave.Models;

namespace LinearSineWave.ViewModels;

public partial class ArtistTrackViewModel : ViewModelBase
{
    public int MainTabSelectedIndex { get; set; } = 0;
    public ObservableCollection<TrackModel> Tracks { get; }

    public ArtistTrackViewModel()
    {
        /*var people = new List<Person> 
        {
            new Person("Neil", "Armstrong"),
            new Person("Buzz", "Lightyear"),
            new Person("James", "Kirk")
        };*/

        List<TrackModel> tracks = new List<TrackModel>();
        
        for (int i = 0; i < 50; i++)
        {
            tracks.Add(new TrackModel
            {
                TrackIdx = i,
                TrackKey = i,
                LibraryGuid = "123456798",
                TrackTitle = "Track Title",
                TrackArtist = "Track Artist",
                TrackAlbum = "Track Album",
                TrackYear = "2016",
                TrackNumber = 99,
                GenreKey = "Rock",
                TrackGenre = "Rock",
                TrackName = "My Track",
                TrackPath = "smb://path",
                TrackExtension = ".mp3",
                TrackComment = "Comment",
                TrackHasBeenUpdated = false
            });
        }
        
        Tracks = new ObservableCollection<TrackModel>(tracks);
    }
}