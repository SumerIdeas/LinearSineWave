using Avalonia;
using System;
using Microsoft.Extensions.Configuration;

namespace LinearSineWave;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        LoadConfiguration();
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    private static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    
    private static void LoadConfiguration() {
        try {
            var configuration =  new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json").Build();
            
            string applicationName = configuration["Application:Name"];
            string version = configuration["Application:Version"];
            string ApplicationDatabaseName = configuration["ApplicationDatabaseName:Version"];
            string TrackDatabaseName = configuration["TrackDatabaseName:Version"];
            
            Settings.ApplicationName = applicationName;
            Settings.Version = version;
            Settings.ApplicationDatabaseName = ApplicationDatabaseName;
            Settings.TrackDatabaseName = TrackDatabaseName;
        }
        catch (Exception ex) {
            Exception _exception = ex;
        }
    }
    
    
}



















