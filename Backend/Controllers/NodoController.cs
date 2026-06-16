using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NodoController : ControllerBase
{
    private readonly INodoService _nodoService;

    public NodoController(INodoService nodoService)
    {
        _nodoService = nodoService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Nodos>>> GetAll()
    {
        return Ok(await _nodoService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Nodos>> GetById(int id)
    {
        var nodo = await _nodoService.GetById(id);

        if (nodo == null)
            return NotFound();

        return Ok(nodo);
    }

    [HttpPost]
    public async Task<ActionResult<Nodos>> Create(Nodos nodo)
    {
        var nuevo = await _nodoService.Create(nodo);

        return CreatedAtAction(
            nameof(GetById),
            new { id = nuevo.IDNodo },
            nuevo
        );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Nodos>> Update(
        int id,
        Nodos nodo)
    {
        var actualizado =
            await _nodoService.Update(id, nodo);

        if (actualizado == null)
            return NotFound();

        return Ok(actualizado);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Nodos>> Delete(int id)
    {
        var eliminado =
            await _nodoService.Delete(id);

        if (eliminado == null)
            return NotFound();

        return Ok(eliminado);
    }
}