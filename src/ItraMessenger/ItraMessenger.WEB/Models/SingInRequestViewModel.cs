using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ItraMessenger.WEB.Models;

public class SingInRequestViewModel
{
    [Required]
    [MinLength(1)]
    [DisplayName("Username")]
    public string UserName { get; set; }
}