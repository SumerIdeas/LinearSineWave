using CommunityToolkit.Mvvm.ComponentModel;
using LinearSineWave.Data;

namespace LinearSineWave.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ApplicationPages _pageName;
}