using DrawGheterInfrastructure.Controllers.Dto;
using DrawGheterInfrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DrawGheterInfrastructure.Controllers;

[ApiController]
[Route("[action]")]
public class BaseController<TService, TEntity, TCreateDto, TUpdateDto>(TService service) : Controller
    where TService : IBaseService<TEntity, TCreateDto, TUpdateDto>
    where TCreateDto : IBaseDto<TEntity>
    where TUpdateDto : IBaseDto<TEntity>
{
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        service.Delete(id);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteRange([FromBody] IEnumerable<int> ids)
    {
        service.DeleteRange(ids);
        return Ok();
    }

    [HttpPost]
    public IActionResult Create([FromBody] TCreateDto dto)
    {
        try
        {
            return Ok(service.Create(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] TUpdateDto dto)
    {
        try
        {
            return Ok(service.Update(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateRange([FromBody] IEnumerable<TCreateDto> dtos)
    {
        return Ok(service.CreateRange(dtos));
    }

    [HttpPut]
    public IActionResult UpdateRange([FromBody] IEnumerable<TUpdateDto> dtos)
    {
        return Ok(service.UpdateRange(dtos));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(service.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult Show(int id)
    {
        var entity = service.Show(id);
        if (entity == null)
        {
            return NotFound();
        }

        return Ok(entity);
    }
}