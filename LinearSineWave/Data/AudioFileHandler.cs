using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ATL;
using Avalonia;
using LinearSineWave.Models.Audio;

namespace LinearSineWave.Data;

public class AudioFileHandler
{
    private readonly LswDatabase _lswDatabase;
    private App app;
    
    public AudioFileHandler()
    {
        app = (App)Application.Current;
        _lswDatabase = new LswDatabase();    
    }


    public void ReadFilesAndFolders()
    {
        string path = "/home/dcrump/Documents/Shares/Music";
        List<TrackModel> tracks = new List<TrackModel>();
        int cnt = 1;

        try {
            string[] fileExt = app.AllowedAudioExtentions.Split(',');

            var fileList = Directory
                            .EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                            .Where(file => fileExt.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase)));
            
            foreach (string file in fileList) {
                Track currentTrack = new Track(file);
                FileInfo fileInfo = new FileInfo(file);
                
                tracks.Add(new TrackModel {
                    TrackIdx = cnt,
                    TrackKey = cnt,
                    LibraryGuid = "123456798",
                    TrackTitle = currentTrack.Title,
                    TrackArtist = currentTrack.Artist,
                    TrackAlbum = currentTrack.Album,
                    TrackYear = currentTrack.Year.ToString() ?? "",
                    TrackNumber = currentTrack.TrackNumber ?? 0,
                    GenreKey = currentTrack.Genre,
                    TrackGenre = currentTrack.Genre,
                    TrackName = currentTrack.Artist,
                    TrackPath = file,
                    TrackExtension = fileInfo.Extension,
                    TrackComment = currentTrack.Comment,
                    TrackHasBeenUpdated = false
                });

                cnt++;
            }
            
            var result = _lswDatabase.AddTracks(tracks);
            
            /*DirectoryInfo dir = new(path);

            foreach (DirectoryInfo direct in dir.GetDirectories())
            {
                Console.WriteLine(direct.FullName);
                foreach (FileInfo file in direct.EnumerateFiles())
                {
                    Console.WriteLine(file.FullName);                
                }
            }*/
        }
        catch (Exception ex)
        {
            Exception _ex = ex;
        }
    }
}