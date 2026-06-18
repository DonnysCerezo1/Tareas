using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly IReservasService _service;

    public ReservasController(IReservasService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Reservas reserva)
    {
        var creada = await _service.Create(reserva);

        return Ok(creada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.Delete(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}