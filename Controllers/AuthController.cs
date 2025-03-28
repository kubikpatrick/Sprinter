using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Sprinter.Models.Identity;
using Sprinter.Models.Rest;

namespace Sprinter.Controllers;

[Route("auth")]
public sealed class AuthController : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet("sign-up")]
    public ActionResult SignUp()
    {
        return View();
    }

    [HttpPost("sign-up")]
    public async Task<ActionResult> SignUp([FromForm] SignUpModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user  = await _userManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
            ModelState.AddModelError("Email", "Email already taken.");

            return View(model);
        }

        user = new User
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Avatar = model.Avatar.FileName,
            CreatedAt = DateTime.Now
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return View(model);
        }

        await _signInManager.SignInAsync(user, true);

        if (!string.IsNullOrEmpty(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return RedirectToAction(nameof(Index), "Account");
        }
    }
        

    [HttpGet("login")]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromForm] LoginModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        bool exists = await _userManager.FindByEmailAsync(model.Email) != null;
        if (!exists)
        {
            ModelState.AddModelError("Email", "Email not found.");

            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("Password", "Invalid password.");

            return View(model);
        }

        if (!string.IsNullOrEmpty(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return RedirectToAction(nameof(Index), "Account");
        }
    }
}
