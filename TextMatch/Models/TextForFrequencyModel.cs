using System.ComponentModel.DataAnnotations;

namespace TextMatch.Models;

/// <summary>
/// The TextForFrequency object model.
/// </summary>
public class TextForFrequency
{
    /// <summary>
    /// The Text 
    /// </summary>
    [Required(ErrorMessage = "Please enter your paragraph")]
    [MaxLength(524288, ErrorMessage = @"The maximum length of characters is {0}")]
    public string Text { get; set; } = null!;

    /// <summary>
    /// The SubText
    /// </summary>
    [Required(ErrorMessage = "Please enter text")]
    [MaxLength(50, ErrorMessage = @"The maximum length of characters is {0}")]
    public string SubText { get; set; } = null!;

}
