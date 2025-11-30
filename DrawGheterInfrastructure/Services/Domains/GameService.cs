using DrawGheterInfrastructure.Controllers.Dto.GameDomain;
using DrawGheterInfrastructure.Models;
using DrawGheterInfrastructure.Repositories.Intefaces;
using DrawGheterInfrastructure.Services.Interfaces;

namespace DrawGheterInfrastructure.Services.Domains;

public class GameService(IGameRepository repository)
    : BaseService<Game, CreateGameDto, UpdateGameDto>(repository), IGameService
{
}