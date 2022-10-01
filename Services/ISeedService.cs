using Education.Models;

namespace Education.Services;

public interface ISeedService
{
  public  Task InitializeRoleAsync(string role);
  public Task InitializeUserAsync(RoleViewModel model);
}