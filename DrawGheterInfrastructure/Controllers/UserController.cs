using DrawGheterInfrastructure.Controllers.Dto;
using DrawGheterInfrastructure.Services;
using DrawGheterInfrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DrawGheterInfrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : Controller
{
    [HttpPost]
    public IActionResult Create([FromBody] CreateUserDto userDto)
    {
        return Ok(userService.Create(userDto));
    }

    [HttpPut]
    public IActionResult Update([FromBody] UpdateUserDto userDto)
    {
        return Ok(userService.Update(userDto));
    }
}