using LinearSineWave.Data;
using LinearSineWave.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LinearSineWave.Services;

public static class ServiceHandler
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddTransient<MainViewModel>()
            .AddSingleton<ArtistTrackViewModel>()
            .AddSingleton<ConfigurationViewModel>()
            .AddSingleton<ILswDatabase, LswDatabase>();
    }
}