using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LinearSineWave.Views;

public partial class ArtistTrackView : UserControl
{
    public ArtistTrackView()
    {
        InitializeComponent();
    }
    
    public void ArtistTrackTabChangeHandler(object sender, SelectionChangedEventArgs args)
    {
        string tst = string.Empty;
        TabControl tc = (TabControl)sender;
        int se = tc.SelectedIndex;
    }
}