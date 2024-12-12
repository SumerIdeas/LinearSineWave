using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LinearSineWave.Models.Audio;
using LiteDB;

namespace LinearSineWave.Data;

public class LswDatabase
{
    #region Variables
    // ------------------------------------------------
    //      Variables
    private LiteDatabase _applicationDatabase;
    private LiteDatabase _trackDatabase;
    
    private ILiteCollection<LibraryModel> _libraryCollection;
    private ILiteCollection<GenreModel> _genreCollection;
    private ILiteCollection<TagModel> _tagCollection;
    private ILiteCollection<TagVersionModel> _tagVersionCollection;
    
    private ILiteCollection<TrackModel> _trackCollection;

    private Exception _lastError;
    // ------------------------------------------------
    #endregion
    
    #region Properties
    // ------------------------------------------------
    //      Properties
    internal LiteDatabase ApplicationDatabase => _applicationDatabase;
    internal LiteDatabase TrackDatabase => _trackDatabase;
    internal Exception LastError => _lastError;
    // ------------------------------------------------
    #endregion
    
    
    internal LswDatabase() {
        try {
            ConnectDatabase();
            RefreshCollections();
        }
        catch (Exception ex)
        {
            Exception _ex = ex;
        }
    }

    #region Internal
    // ---------------------------------------
    //      Refresh Collections
    public void ConnectDatabase() {
        try {
            if (_applicationDatabase != null)
                _applicationDatabase.Dispose();
            if (_trackDatabase != null)
                _trackDatabase.Dispose();

            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string databasePath = Path.GetDirectoryName(path) + Path.DirectorySeparatorChar + "Database";
            
            if (!Path.Exists(databasePath))
                Directory.CreateDirectory(databasePath);

            string applicationDatabasePath = databasePath + Path.DirectorySeparatorChar + "ApplicationDatabase.db";
            string trackDatabasePath = databasePath + Path.DirectorySeparatorChar + "TrackDatabase.db";
            
            _applicationDatabase = new LiteDatabase(applicationDatabasePath);
            _trackDatabase = new LiteDatabase(trackDatabasePath);
        }
        catch(Exception ex) {
            _lastError = ex;
        }
    }

    public Exception GetLastException() {
        return _lastError;
    }
    
    public async Task RefreshCollections() {
        _libraryCollection = await Task.Run(() => ApplicationDatabase.GetCollection<LibraryModel>("library"));
        _genreCollection = await Task.Run(() => ApplicationDatabase.GetCollection<GenreModel>("genre"));
        _tagCollection = await Task.Run(() => ApplicationDatabase.GetCollection<TagModel>("tag"));
        _tagVersionCollection = await Task.Run(() => ApplicationDatabase.GetCollection<TagVersionModel>("tagVersion"));
        _trackCollection = await Task.Run(() => TrackDatabase.GetCollection<TrackModel>("track"));
    }
    #endregion

    #region Tracks
    // ---------------------------------------
    //      Insert Track
    // ---------------------------------------
    public async Task<bool> AddTrack(TrackModel track) {
        try {
            await Task.Run(() => _trackCollection.Insert(track));
            return true;
        }
        catch (Exception ex) {
            _lastError = ex;
            return false;
        }
    }

    public async Task<bool> AddTracks(List<TrackModel> track) {
        try {
            await Task.Run(() => _trackCollection.InsertBulk(track));
            return true;
        }
        catch (Exception ex) {
            _lastError = ex;
            return false;
        }
    }
    
    // Some tracks from different bands or albums may have duplicate names. This will list all of them
    public async Task<List<TrackModel>>? GetTrackListByName(string trackName) {
        List<TrackModel>? trackList = new List<TrackModel>();
        
        try {
            trackList = await Task.Run(() => _trackDatabase
                                        .GetCollection<TrackModel>("track")
                                        .Find(x => x.TrackName == trackName)
                                        .ToList());
            return trackList;
        }
        catch (Exception ex) {
            _lastError = ex;
            return trackList;
        }
    }
    public async Task<TrackModel>? GetTrack(string trackName) {
        TrackModel? track = null;
        
        try {
            track = await Task.Run(() => _trackCollection.FindOne(x => x.TrackName == trackName));
            return track;
        }
        catch (Exception ex) {
            _lastError = ex;
            return track;
        }
    }
    public async Task<TrackModel>? GetTrack(string trackName, string trackAlbum) {
        TrackModel? track = null;
        
        try {
            track = await Task.Run(() => _trackCollection.FindOne(x => x.TrackName == trackName && x.TrackAlbum == trackAlbum));
            return track;
        }
        catch (Exception ex) {
            _lastError = ex;
            return track;
        }
    }
    public async Task<TrackModel>? GetTrack(string trackName, string trackAlbum, string trackArtist) {
        TrackModel? track = null;
        
        try {
            track = await Task.Run(() => _trackCollection.FindOne(x => x.TrackName == trackName && x.TrackAlbum == trackAlbum && x.TrackArtist == trackArtist));
            return track;
        }
        catch (Exception ex) {
            _lastError = ex;
            return track;
        }
    }
    
    public async Task<List<TrackModel>>? SearchTracks(TrackModel track) {
        List<TrackModel>? trackList = new List<TrackModel>();
        
        try {
            trackList = await Task.Run(() => _trackDatabase.GetCollection<TrackModel>("track").FindAll().ToList());
            return trackList;
        }
        catch (Exception ex) {
            _lastError = ex;
            return trackList;
        }
    }
    // ---------------------------------------
    #endregion
    
}