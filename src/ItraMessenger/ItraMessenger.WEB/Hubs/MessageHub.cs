using ItraMessenger.Infrastructure.Identity;
using ItraMessenger.WEB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace ItraMessenger.WEB.Hubs;

[Authorize]
public class MessageHub : Hub
{
    private readonly IMessagesService _messagesService;
    private readonly UserManager<ApplicationUser> _userManager;

    public MessageHub(IMessagesService messagesService, UserManager<ApplicationUser> userManager)
    {
        _messagesService = messagesService;
        _userManager = userManager;
    }

    public async Task SendMessage(string recipientName, string title, string body)
    {
        var sendedMessage = await _messagesService
            .SendMessageAsync(recipientName, title, body);
        var recipient = await _userManager.FindByNameAsync(sendedMessage.RevieverName);
        if (recipient?.UserName != null)
        {
            await Clients.User(recipient.Id).SendAsync("ReceiveMessage",
                sendedMessage.SenderName,
                sendedMessage.Title,
                sendedMessage.Body,
                sendedMessage.Date);
            return;
        }
        await SendMessageToUnknownUser(sendedMessage.SenderName, sendedMessage.RevieverName);
    }

    public async Task SendMessageToUnknownUser(string senderName, string receiverName)
    {
        var sender = await _userManager.FindByNameAsync(senderName);
        await Clients.User(sender.Id).SendAsync("SendToUnknownUser", receiverName);
    }
}