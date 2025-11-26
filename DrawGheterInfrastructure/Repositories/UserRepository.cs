using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Repositories;

public class UserRepository(AppDbContext context)
{
    public User Create(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }
}