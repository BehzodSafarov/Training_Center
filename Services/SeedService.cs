using Education.Models;
using Microsoft.AspNetCore.Identity;

namespace Education.Services;
public class SeedService : ISeedService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<SeedService> _logger;

    public SeedService(
    ILogger<SeedService> logger,
    UserManager<IdentityUser> userManager,
    RoleManager<IdentityRole> roleManager)
    {
      _userManager = userManager;
      _roleManager = roleManager;
      _logger = logger;

    }  
    public async Task InitializeRoleAsync(string role)
    {
        try
        {
          if(!await _roleManager.RoleExistsAsync(role))
          {
           var newRole  = new IdentityRole(role);
           var result = await _roleManager.CreateAsync(newRole);
            
            foreach (var item in _roleManager.Roles)
            {
              System.Console.WriteLine(item);
            }
            if(result.Succeeded)
            {
                _logger.LogInformation($"Role created successefully{result.Succeeded}");
            }
            else
            {
              _logger.LogInformation($"Role didn't created successefully {result.Errors}");
            }
          }
          else
          {
          var natija =   _roleManager.Roles.Select(x => x.Name);
        
            _logger.LogInformation($"This role already exist to as");
          }
        }
        catch (System.Exception e)
        {
         _logger.LogInformation($"Role didn't created {e.Message}");
          
         throw new Exception(e.Message);
        }
    }

    public async Task InitializeUserAsync(RoleViewModel model)
    {
      try
      {
        var newUser = new IdentityUser(model.UserName);

        var result = await _userManager.CreateAsync(newUser,model.Password);

        if(result.Succeeded)
        {
             
            var addRole = await _userManager.AddToRoleAsync(newUser,model.RoleName);
            var resut = _userManager.Users.Select(x =>x.UserName).ToList();
            
            if(addRole.Succeeded)
            {
                _logger.LogInformation($"Role addat sucssefully to user {addRole.Succeeded}");
            }
            else
            {
            _logger.LogInformation($"Role didn't added sucsessefuly to user {addRole.Errors}");
            }
        }
        else
        {
        _logger.LogInformation($"User didn't created ");

        }
      }
      catch (System.Exception e)
      {
        _logger.LogInformation($"User didn't created");
        throw new Exception("user didn't crated");
      }
    }
}