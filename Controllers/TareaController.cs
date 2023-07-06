using Microsoft.AspNetCore.Mvc;
using MyFirstDotnetAPI.Models;
using MyFirstDotnetAPI.Services;

namespace MyFirstDotnetAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareaService _tareaService;

    public TareaController(ITareaService tareaService)
    {
        _tareaService = tareaService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        _tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        _tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id]")]
    public IActionResult Delete(Guid id)
    {
        _tareaService.Delete(id);
        return Ok();
    }
}