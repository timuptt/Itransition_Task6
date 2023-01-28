using System.Diagnostics;
using ItraMessenger.Infrastructure.Identity;
using ItraMessenger.WEB.Hubs;
using Microsoft.AspNetCore.Mvc;
using ItraMessenger.WEB.Models;
using ItraMessenger.WEB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ItraMessenger.WEB.Controllers;

[Authorize]
public class MessagesController : Controller
{
    private readonly ILogger<MessagesController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMessagesService _messagesService;

    public MessagesController(ILogger<MessagesController> logger, IMessagesService messagesService,
        UserManager<ApplicationUser> userManager, IHubContext<MessageHub> hubContext)
    {
        _logger = logger;
        _messagesService = messagesService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _messagesService.GetReceivedMessagesAsync());
    }
    
    [AllowAnonymous]
    public async Task<IActionResult> GetUserNamesByPrefix(string? term)
    {
        var users = await _userManager.Users
            .Select(u => u.UserName)
            .ToListAsync();
        return Json(term is null ? users : users.Where(u => u.StartsWith(term, StringComparison.InvariantCulture)).Take(10));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}