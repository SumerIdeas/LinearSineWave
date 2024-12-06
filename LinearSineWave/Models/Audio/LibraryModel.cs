using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LinearSineWave.Models.Audio;

public class LibraryModel : ObservableValidator
{
    [Required] public int LibraryKey { get; set; }
    
    [Required] public string LibraryGUID { get; set; }
    
    [Required] public string LibraryLocation { get; set; }

    [Required] public string LibraryName { get; set; }

    [Required] public DateTime LibraryDateCreated { get; set; } = DateTime.Now;
}