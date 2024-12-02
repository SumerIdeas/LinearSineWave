using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using LinearSineWave.Data;
using LinearSineWave.Factories;
using LinearSineWave.ViewModels;
using LinearSineWave.Views;
using Microsoft.Extensions.DependencyInjection;

namespace LinearSineWave;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<MainViewModel>();
            serviceCollection.AddSingleton<ArtistTrackViewModel>();
            serviceCollection.AddTransient<ConfigurationViewModel>();
            serviceCollection.AddSingleton<PageFactory>();
            
            serviceCollection.AddSingleton<Func<ApplicationPages, PageViewModel>>(x => name => name switch
            {
                ApplicationPages.Configuration => x.GetRequiredService<ConfigurationViewModel>(),
                _ => throw new InvalidOperationException()
            });
            
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            BindingPlugins.DataValidators.RemoveAt(0);
            
            desktop.MainWindow = new MainView
            {
                DataContext = serviceProvider.GetRequiredService<MainViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}