using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace LinearSineWave.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
    }
    
    public void LeftNavbarClickHandler(object sender, RoutedEventArgs args)
    {
        Button button = (Button)sender;
        String btn = String.Empty;
        
        switch (button.Name)
        {
            case "ViewLibraryGrid":
                btn = "ViewLibraryGrid";
                break;
            case "RefreshLibraryWithDatabase":
                btn = "RefreshLibraryWithDatabase";
                break;
            case "Configuration":
                btn = "Configuration";
                break;
            default:
                break;
        }
        
        //message.Text = "Button clicked!";
    }

}