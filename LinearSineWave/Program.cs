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
            
            string test = configuration["AppConfig:Setting1"];
        }
        catch (Exception ex) {
            Exception _exception = ex;
        }
    }
    
    
}