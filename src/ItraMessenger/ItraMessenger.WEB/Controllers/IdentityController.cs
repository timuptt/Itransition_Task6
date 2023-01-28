using ItraMessenger.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ItraMessenger.WEB.Controllers;

public class IdentityController : Controller
{
    private const string DefaultPassword = "1";
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public IdentityController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> SignIn(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user is null) return await Register(userName);
        await _signInManager.SignInAsync(user, false);
        return RedirectToAction("Index", "Messages");
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index");
    }

    private async Task<IActionResult> Register(string userName)
    {
        var user = new ApplicationUser() { UserName = userName };
        var result = await _userManager.CreateAsync(user, DefaultPassword);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Messages");
        }
        return View("Index");
    }
}