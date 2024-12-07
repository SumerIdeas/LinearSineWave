using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using LinearSineWave.Data;
using LinearSineWave.Services;
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
        BindingPlugins.DataValidators.RemoveAt(0);
        
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddCommonServices();
        var services = serviceCollection.BuildServiceProvider();
        
        var vwModel = services.GetRequiredService<MainViewModel>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainView
            {
                DataContext = vwModel
            };
        }
        
        /*if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {

            desktop.MainWindow = new MainView
            {
                DataContext = new MainViewModel(),
            };
        }*/

        base.OnFrameworkInitializationCompleted();
    }
}