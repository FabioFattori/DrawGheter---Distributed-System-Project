using DrawGheterInfrastructure.Models;
using DrawGheterInfrastructure.Repositories.Intefaces;

namespace DrawGheterInfrastructure.Repositories;

public class GameRepository(AppDbContext context) : BaseRepository<Game>(context), IGameRepository
{
}