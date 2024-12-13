using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
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
    private string _applicationDatabasePath;
    private string _trackDatabasePath;
    
    private ILiteCollection<LibraryModel> _libraryCollection;
    private ILiteCollection<GenreModel> _genreCollection;
    private ILiteCollection<TagModel> _tagCollection;
    private ILiteCollection<TagVersionModel> _tagVersionCollection;
    
    private ILiteCollection<TrackModel> _trackCollection;

    private Exception _lastError;
    private string _applicationDatabaseName;
    private string _trackDatabaseName;
    private string _databaseDirectory;
    // ------------------------------------------------
    #endregion
    
    #region Properties
    // ------------------------------------------------
    //      Properties
    internal Exception LastError => _lastError;
    // ------------------------------------------------
    #endregion
    
    
    internal LswDatabase() {
        try {
            App app = (App)Application.Current;
            _applicationDatabasePath= app.ApplicationDatabasePath;
            _trackDatabasePath = app.TrackDatabasePath;
            
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
            _applicationDatabase.Dispose();
            _trackDatabase.Dispose();
            
            _applicationDatabase = new LiteDatabase(_applicationDatabasePath);
            _trackDatabase = new LiteDatabase(_trackDatabasePath);
        }
        catch(Exception ex) {
            _lastError = ex;
        }
    }

    public Exception GetLastException() {
        return _lastError;
    }
    
    public async Task RefreshCollections() {
        _libraryCollection = await Task.Run(() => _applicationDatabase.GetCollection<LibraryModel>("library"));
        _genreCollection = await Task.Run(() => _applicationDatabase.GetCollection<GenreModel>("genre"));
        _tagCollection = await Task.Run(() => _applicationDatabase.GetCollection<TagModel>("tag"));
        _tagVersionCollection = await Task.Run(() => _applicationDatabase.GetCollection<TagVersionModel>("tagVersion"));
        _trackCollection = await Task.Run(() => _trackDatabase.GetCollection<TrackModel>("track"));
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

    // This is only used when a new database is detected.
    //      After that an update/add needs to be used.
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