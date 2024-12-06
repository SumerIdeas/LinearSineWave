using System;
using System.Collections.Generic;
using System.Linq;
using LinearSineWave.Models.Audio;
using LiteDB;

namespace LinearSineWave.Data;

public class LswDatabase : ILswDatabase
{
    #region Variables
    // ------------------------------------------------
    //      Variables
    private LiteDatabase _applicationDatabase;
    private LiteDatabase _trackDatabase;
    
    private ILiteCollection<LibraryModel> _libraryCollection = null!;
    private ILiteCollection<GenreModel> _genreCollection = null!;
    private ILiteCollection<TagModel> _tagCollection = null!;
    private ILiteCollection<TagVersionModel> _tagVersionCollection = null!;
    
    private ILiteCollection<TrackModel> _trackCollection = null!;

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
    
    
    internal LswDatabase()
    {
        try
        {
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
    public void ConnectDatabase()
    {
        try
        {
            if (_applicationDatabase != null)
                _applicationDatabase.Dispose();
            if (_trackDatabase != null)
                _trackDatabase.Dispose();

            _applicationDatabase = new LiteDatabase("ApplicationDatabase.db");
            _trackDatabase = new LiteDatabase("TrackDatabase.db");
        }
        catch(Exception ex)
        {
            _lastError = ex;
        }
    }

    public Exception GetLastException()
    {
        return _lastError;
    }
    
    public void RefreshCollections()
    {
        _libraryCollection = ApplicationDatabase.GetCollection<LibraryModel>("library");
        _genreCollection = ApplicationDatabase.GetCollection<GenreModel>("genre");
        _tagCollection = ApplicationDatabase.GetCollection<TagModel>("tag");
        _tagVersionCollection = ApplicationDatabase.GetCollection<TagVersionModel>("tagVersion");
        _trackCollection = TrackDatabase.GetCollection<TrackModel>("track");
    }
    #endregion

    #region Tracks
    // ---------------------------------------
    //      Insert Track
    // ---------------------------------------
    internal bool AddTrack(TrackModel track) {
        try {
            _trackCollection.Insert(track);
            return true;
        }
        catch (Exception ex) {
            _lastError = ex;
            return false;
        }
    }

    internal List<TrackModel>? GetTrackListByName(string trackName) {
        try {
            return _trackDatabase.GetCollection<TrackModel>("track").Find(x => x.TrackName == trackName).ToList();
        }
        catch (Exception ex) {
            _lastError = ex;
            return null;
        }
    }
    internal TrackModel? GetTrack(string trackName) {
        try {
            return _trackCollection.FindOne(x => x.TrackName == trackName);
        }
        catch (Exception ex) {
            _lastError = ex;
            return null;
        }
    }
    internal TrackModel? GetTrack(string trackName, string trackAlbum) {
        try {
            return _trackCollection.FindOne(x => x.TrackName == trackName && x.TrackAlbum == trackAlbum);
        }
        catch (Exception ex) {
            _lastError = ex;
            return null;
        }
    }
    internal TrackModel? GetTrack(string trackName, string trackAlbum, string trackArtist) {
        try {
            return _trackCollection.FindOne(x => x.TrackName == trackName && x.TrackAlbum == trackAlbum && x.TrackArtist == trackArtist);
        }
        catch (Exception ex) {
            _lastError = ex;
            return null;
        }
    }
    
    internal List<TrackModel>? SearchTracks(TrackModel track) {
        try {
            return _trackDatabase.GetCollection<TrackModel>("track").FindAll().ToList();
        }
        catch (Exception ex) {
            _lastError = ex;
            return null;
        }
    }
    // ---------------------------------------
    #endregion
    
    
}