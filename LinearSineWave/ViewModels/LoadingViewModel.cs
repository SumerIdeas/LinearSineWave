using System.Threading;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LinearSineWave.ViewModels;

public partial class LoadingViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _title = "Starting Application ...";
    private readonly CancellationTokenSource _cts = new();
    public CancellationToken CancellationToken => _cts.Token;

    public bool HasLoaded { get; private set; } = false;
    
    public void Cancel()
    {
        _title = "Cancelling";
        _cts.Cancel();
    }
    

    
}