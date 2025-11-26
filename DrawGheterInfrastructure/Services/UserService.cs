using DrawGheterInfrastructure.Models;
using DrawGheterInfrastructure.Repositories;

namespace DrawGheterInfrastructure.Services;

public class UserService(UserRepository userRepository)
{
    public User CreateRandomUser()
    {
        return userRepository.Create(
            new User
            {
                Email = Guid.NewGuid().ToString(),
                Username = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
            }
        );
    }
}