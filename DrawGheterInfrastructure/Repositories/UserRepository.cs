using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context)
{
}