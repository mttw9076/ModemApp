using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AjaxLogin(string Email, string Password)
    {
        var user = await _userManager.FindByEmailAsync(Email);
        if (user == null)
            return Json(new { success = false, message = "Nieprawidłowy email lub hasło." });

        var result = await _signInManager.PasswordSignInAsync(user, Password, false, false);
        if (result.Succeeded)
            return Json(new { success = true });

        return Json(new { success = false, message = "Logowanie nie powiodło się." });
    }
}
