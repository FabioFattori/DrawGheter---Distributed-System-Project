using DrawGheterInfrastructure.Controllers.Dto.GameDomain;
using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Services.Interfaces;

public interface IGameService : IBaseService<Game, CreateGameDto, UpdateGameDto>
{
    
}