using Microsoft.AspNetCore.Mvc;
using MyFirstDotnetAPI.Models;
using MyFirstDotnetAPI.Services;

namespace MyFirstDotnetAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_categoriaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        _categoriaService.Save(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        _categoriaService.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id]")]
    public IActionResult Delete(Guid id)
    {
        _categoriaService.Delete(id);
        return Ok();

    }
}