using Avalonia.Controls;

namespace LinearSineWave.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
    }
    
    public void MainTabChangeHandler(object sender, SelectionChangedEventArgs args)
    {
        string tst = string.Empty;
        TabControl tc = (TabControl)sender;
        int se = tc.SelectedIndex;
    }
}