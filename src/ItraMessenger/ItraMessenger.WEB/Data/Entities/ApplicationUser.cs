using ItraMessenger.ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;

namespace ItraMessenger.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public ICollection<Message> RecievedMessages { get; set; }
}