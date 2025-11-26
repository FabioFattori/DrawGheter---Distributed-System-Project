using DrawGheterInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace DrawGheterInfrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserService userService) : Controller
{
    [HttpPost]
    public IActionResult Create()
    {
        return Ok(userService.CreateRandomUser());
    }
}