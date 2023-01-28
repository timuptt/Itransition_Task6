using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using ItraMessenger.ApplicationCore.Models;
using ItraMessenger.Infrastructure.Identity;
using ItraMessenger.WEB.Data.Contexts;
using ItraMessenger.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ItraMessenger.WEB.Services;

public class MessagesService : IMessagesService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ApplicationDbContext _dbContext;

    public MessagesService(IHttpContextAccessor contextAccessor,
        ApplicationDbContext dbContext)
    {
        _httpContextAccessor = contextAccessor;
        _dbContext = dbContext;
    }

    public async Task<Message> SendMessageAsync(string recipientName, string title, string body)
    {
        var newMessage = new Message()
        {
            Id = Guid.NewGuid().ToString(),
            SenderName = GetCurrentUserName(),
            RevieverName = recipientName,
            Title = title,
            Body = body,
            Date = DateTimeOffset.Now
        };
        await _dbContext.Messages.AddAsync(newMessage);
        await _dbContext.SaveChangesAsync();
        return newMessage;
    }

    public async Task<IEnumerable<DisplayMessageViewModel>> GetReceivedMessagesAsync()
    {
        var receivedMessages = _dbContext.Messages
            .Where(m => m.RevieverName == GetCurrentUserName())
            .OrderByDescending(m => m.Date)
            .Select(x => new DisplayMessageViewModel()
            {
                Title = x.Title,
                Body = x.Body,
                SenderName = x.SenderName,
                Date = x.Date
            });
        return receivedMessages;
    }

    private string GetCurrentUserName() => _httpContextAccessor.HttpContext.User.Identity.Name;
}