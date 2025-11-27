using DrawGheterInfrastructure.Controllers.Dto.UserDomain;
using DrawGheterInfrastructure.Models;
using DrawGheterInfrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DrawGheterInfrastructure.Controllers;

[Route("api/[controller]/[action]")]
public class UserController(IUserService userService)
    : BaseController<IUserService, User, CreateUserDto, UpdateUserDto>(userService)
{
}