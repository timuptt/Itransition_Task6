using ItraMessenger.Infrastructure.Identity;

namespace ItraMessenger.ApplicationCore.Models;

public class Message
{
    public string Id { get; set; }
    
    public string SenderName { get; set; }

    public string RevieverName { get; set; }

    public string Title { get; set; }
    
    public string Body { get; set; }
    
    public DateTimeOffset Date { get; set; }
}