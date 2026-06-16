using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AristaController(IAristaService aristaService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Aristas>>> GetAll()
    {
        var aristas = await aristaService.GetAll();

        return Ok(aristas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Aristas>> GetById(int id)
    {
        var arista = await aristaService.GetById(id);

        if (arista == null)
            return NotFound();

        return Ok(arista);
    }

    [HttpPost]
    public async Task<ActionResult<Aristas>> Create(Aristas arista)
    {
        var nuevaArista = await aristaService.Create(arista);

        return CreatedAtAction(
            nameof(GetById),
            new { id = nuevaArista.IDAristas },
            nuevaArista
        );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Aristas>> Update(
        int id,
        Aristas arista)
    {
        var actualizada =
            await aristaService.Update(id, arista);

        if (actualizada == null)
            return NotFound();

        return Ok(actualizada);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Aristas>> Delete(int id)
    {
        var eliminada =
            await aristaService.Delete(id);

        if (eliminada == null)
            return NotFound();

        return Ok(eliminada);
    }
}