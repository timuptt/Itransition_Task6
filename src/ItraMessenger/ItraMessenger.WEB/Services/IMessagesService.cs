using ItraMessenger.ApplicationCore.Models;
using ItraMessenger.WEB.Models;

namespace ItraMessenger.WEB.Services;

public interface IMessagesService
{
    public Task<Message> SendMessageAsync(string recipientName, string title, string body);
    
    public Task<IEnumerable<DisplayMessageViewModel>> GetReceivedMessagesAsync();
}