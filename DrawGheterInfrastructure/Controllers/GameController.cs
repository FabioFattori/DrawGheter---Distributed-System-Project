using DrawGheterInfrastructure.Controllers.Dto.GameDomain;
using DrawGheterInfrastructure.Models;
using DrawGheterInfrastructure.Services.Domains;
using Microsoft.AspNetCore.Mvc;

namespace DrawGheterInfrastructure.Controllers;

[Route("api/[controller]/[action]")]
public class GameController(GameService service) : BaseController<GameService,Game, CreateGameDto, UpdateGameDto>(service)
{
    
}