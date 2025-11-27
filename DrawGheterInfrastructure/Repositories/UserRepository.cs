using DrawGheterInfrastructure.Models;
using DrawGheterInfrastructure.Repositories.Intefaces;
using Microsoft.AspNetCore.Identity;

namespace DrawGheterInfrastructure.Repositories;

public class UserRepository(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
    : BaseRepository<User>(context), IUserRepository
{
    public async Task<bool> Register(User user)
    {
        var result = await userManager.CreateAsync(user, user.Password);
        if (!result.Succeeded)
        {
            return false;
        }

        await signInManager.SignInAsync(user, isPersistent: false);
        return true;
    }

    public async Task<bool> Login(User user)
    {
        if (user.Email == null)
        {
            return false;
        }

        var result = await signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);
        return result.Succeeded;
    }
}