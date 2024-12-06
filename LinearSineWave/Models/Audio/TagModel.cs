using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LinearSineWave.Models.Audio;

public class TagModel : ObservableValidator
{
    [Required]
    public int TagKey { get; set; }
    
    [Required]
    public int TagVersionKey { get; set; }
    
    [Required]
    public string TagIndex { get; set; }
    
    [Required]
    public string TagId { get; set; }
    
    [Required]
    public string TagName { get; set; }
    
    [Required]
    public int TagValueLink { get; set; }
    
    [Required]
    public bool TagIsCustom { get; set; }
}