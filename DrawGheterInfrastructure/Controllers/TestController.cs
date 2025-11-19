using Microsoft.AspNetCore.Mvc;

namespace DrawGheterInfrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello World!");
    }

    [HttpGet("{id:int}")]
    public IActionResult Show(int id)
    {
        return Ok($"Hello World! Hai passato {id}");
    }
}