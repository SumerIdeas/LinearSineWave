using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using LinearSineWave.ViewModels;
using LinearSineWave.Views;
using LiteDB;
using Microsoft.Extensions.Configuration;

namespace LinearSineWave;

public partial class App : Application
{
    private IConfigurationRoot _configuration { get; set; }
    
    public string ApplicationName { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string ApplicationDatabaseName { get; set; } = string.Empty;
    public string TrackDatabaseName { get; set; } = string.Empty;
    public string DatabaseDirectory { get; set; } = string.Empty;
    public string ApplicationDatabasePath { get; set; } = string.Empty;
    public string TrackDatabasePath { get; set; } = string.Empty;
    
    public override void Initialize()
    {
        LoadConfiguration();
        InitDatabase();
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted() {
        BindingPlugins.DataValidators.RemoveAt(0);
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            desktop.MainWindow = new MainView
            {
                DataContext = new MainViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void LoadConfiguration()
    {
        try {
            _configuration =  new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json").Build();

            ApplicationName = _configuration["Application:Name"] ?? "NOTFOUND";
            Version = _configuration["Application:Version"] ?? "NOTFOUND";
            ApplicationDatabaseName = _configuration["Application:ApplicationDatabaseName"] ?? "NOTFOUND";
            TrackDatabaseName = _configuration["Application:TrackDatabaseName"] ?? "NOTFOUND";
            DatabaseDirectory = _configuration["Application:DatabaseDirectory"] ?? "NOTFOUND";
        }
        catch (Exception ex) {
            Exception _exception = ex;
        }
    }

    private void InitDatabase()
    {
        try {
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string databasePath = Path.GetDirectoryName(path) + Path.DirectorySeparatorChar + DatabaseDirectory;

            if (!Path.Exists(databasePath))
                Directory.CreateDirectory(databasePath);
            
            ApplicationDatabasePath = databasePath + Path.DirectorySeparatorChar + ApplicationDatabaseName;
            TrackDatabasePath = databasePath + Path.DirectorySeparatorChar + TrackDatabaseName;
        }
        catch (Exception ex)
        {
            Exception _ex = ex;
        }
    }

}
















