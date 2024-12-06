using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LinearSineWave.Models.Audio;

public class TagVersionModel : ObservableValidator
{
    [Required]
    public int TagVersionKey { get; set; }
    
    [Required]
    public string TagVersion { get; set; }
}