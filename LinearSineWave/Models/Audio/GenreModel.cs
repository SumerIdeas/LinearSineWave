using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LinearSineWave.Models.Audio;

public class GenreModel : ObservableValidator
{
    [Required]
    public int GenreKey { get; set; }
    
    [Required]
    public string GenreDescription { get; set; }
    
    [Required]
    public bool GenreIsCustom { get; set; }
}