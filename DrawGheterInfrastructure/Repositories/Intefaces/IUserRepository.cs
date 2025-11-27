using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Repositories.Intefaces;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<bool> Register(User user);
    public Task<bool> Login(User user);
}