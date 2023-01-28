namespace ItraMessenger.WEB.Models;

public class DisplayMessageViewModel
{
    public string SenderName { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTimeOffset Date { get; set; }
}