using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class RutasDisponiblesController : ControllerBase
{

    private readonly IRutasDisponiblesService _service;


    public RutasDisponiblesController(
        IRutasDisponiblesService service)
    {
        _service = service;
    }
    
    [HttpGet("paradas/{idRuta}")]
    public async Task<IActionResult> GetParadasRuta(int idRuta)
    {
        try
        {
            var resultado = await _service.GetParadasRuta(idRuta);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ruta = await _service.GetById(id);
        if(ruta == null)
            return NotFound();

        return Ok(ruta);
    }
}