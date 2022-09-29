using Education.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.Controllers;
public class AccountController : Controller
{
    private ILogger<AccountController> _logger;
    private UserManager<IdentityUser> _userManager;
    private SignInManager<IdentityUser> _signInManager;

    public AccountController(
    ILogger<AccountController> logger,
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager)
    {
      _logger = logger;
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register(string returnUrl) => View(new RegisterViewModel(){ReturnUrl = returnUrl});

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var student = new IdentityUser(model.UserName);
        var result = await _userManager.CreateAsync(student);

        if(!result.Succeeded)
        {
            _logger.LogInformation($"Student registratsiyadan o'tmadi{result.Errors}");

            return View();
        }

    return LocalRedirect($"/account/login?returnUrl={model.ReturnUrl}");

    }

  [HttpGet]
  public IActionResult Login(string returnUrl) => View(new LoginViewModel(){ReturnUrl = returnUrl});

  [HttpPost]
  public async Task<IActionResult>  Login(LoginViewModel model)
  {
    var student = await _userManager.FindByNameAsync(model.Username);

    if(student is null)
    {
        _logger.LogInformation($"Bu student topilmadi{model.Username}");

        return View(nameof(RegisterViewModel));
    }

    var result = await _signInManager.PasswordSignInAsync(student,model.Password,false,false);

    if(!result.Succeeded)
    {
     _logger.LogInformation($"Signin qilinmadi {result.IsNotAllowed}");

     return View();
    }

    return LocalRedirect($"{model.ReturnUrl ?? "/"}"); 
  }
}