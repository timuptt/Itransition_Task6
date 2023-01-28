using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ItraMessenger.WEB.Models;

public class NewMessageViewModel
{
    [Required]
    [DisplayName("Title")]
    [MinLength(1)]
    public string Title { get; set; }
    
    [Required]
    [DisplayName("Message")]
    [MinLength(1)]
    public string Body { get; set; }
    
    [Required]
    [DisplayName("Recipient")]
    [MinLength(1)]
    public string RecipientName { get; set; }
}