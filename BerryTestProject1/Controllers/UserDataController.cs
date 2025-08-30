using BerryTestProject1.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class UserDataController : Controller
{
    private readonly IUserDataService _userDataService;
    private readonly IUserSessionService _userSessionService;

    public UserDataController(IUserDataService userDataService, IUserSessionService userSessionService)
    {
        _userDataService = userDataService;
        _userSessionService = userSessionService;
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View("~/Views/UserData/SignUp.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserRegistrationVM vm)
    {
        if (!ModelState.IsValid)
            return View("~/Views/UserData/SignUp.cshtml",vm);
        var existingUsers = await _userDataService.GetAllUsersAsync();
        if (existingUsers != null &&
            existingUsers.Any(u => u != null &&
                                   u.Username.Equals(vm.Username, StringComparison.OrdinalIgnoreCase)))
        {
            ModelState.AddModelError(nameof(vm.Username),
                "The username is already registered.");
            return View("~/Views/UserData/SignUp.cshtml", vm);
        }
        _userDataService.RegisterUser(vm);
        return RedirectToAction("Login");
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        var user = await _userDataService.GetUserByUsername(username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }
        var claims = new List<Claim>
    {
        new(ClaimTypes.NameIdentifier, user.Id.ToString()), 
        new(ClaimTypes.Name, user.FullName ?? string.Empty),
        new(ClaimTypes.Email, user.Email ?? string.Empty),
        new("Username", user.Username ?? string.Empty),
        new(ClaimTypes.Role, "User")
    };

        var claimsIdentity = new ClaimsIdentity(claims, "UserCookie");
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = false,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
            AllowRefresh = true
        };
        await HttpContext.SignInAsync(
            "UserCookie",
            new ClaimsPrincipal(claimsIdentity),
            authProperties
        );
        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index", "Home");
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
}
