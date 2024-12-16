using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LinearSineWave.Data;

namespace LinearSineWave.ViewModels;

public partial class LoadingViewModel : ViewModelBase
{
    public bool HasLoaded { get; private set; } = false;

    [ObservableProperty]
    private StringBuilder _statusMessageText = new();
    
    [ObservableProperty]
    private string _statusMessage = string.Empty;
    
    private LswDatabase _lswDatabase;

    public LoadingViewModel() {
        try {
            _lswDatabase = new LswDatabase();
        }
        catch (Exception ex) {
            Exception _ex = ex;
        }
    }

    public async Task StartLoading()
    {
        StatusMessageText.AppendLine("Starting Application...");
        StatusMessage = StatusMessageText.ToString();
        await Task.Delay(30000);
        StatusMessageText.AppendLine("Next 1");
        StatusMessage = StatusMessageText.ToString();
        await Task.Delay(2000);
        StatusMessageText.AppendLine("Next 2");
        StatusMessage = StatusMessageText.ToString();
        await Task.Delay(2000);
        StatusMessageText.AppendLine("Next 3");
        StatusMessage = StatusMessageText.ToString();
        await Task.Delay(2000);
        StatusMessageText.AppendLine("Next 4");
        StatusMessage = StatusMessageText.ToString();
        await Task.Delay(2000);
    }
    
    [RelayCommand]
    public void Cancel()
    {
        
    }
}