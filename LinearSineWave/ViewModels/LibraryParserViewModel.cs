using Avalonia;

namespace LinearSineWave.ViewModels;

public class LibraryParserViewModel : ViewModelBase
{
    private string applicationDatabaseName { get; set; }
    private string trackDatabaseName { get; set; }
    
    public LibraryParserViewModel()
    {
        App app = (App)Application.Current;
        applicationDatabaseName = app.ApplicationDatabaseName;
    }
}