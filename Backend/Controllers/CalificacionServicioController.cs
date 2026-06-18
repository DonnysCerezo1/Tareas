using Backend.Interfaces;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CalificacionServicioController : ControllerBase
{

    private readonly ICalificacionServicioService _service;


    public CalificacionServicioController(
        ICalificacionServicioService service)
    {
        _service = service;
    }





    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }





    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {

        var calificacion = await _service.GetById(id);



        if(calificacion == null)
            return NotFound();



        return Ok(calificacion);
    }





    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CalificacionServicio calificacion)
    {

        var result = await _service.Create(calificacion);


        return Ok(result);
    }





    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] CalificacionServicio calificacion)
    {

        var result = await _service.Update(id, calificacion);



        if(!result)
            return NotFound();



        return NoContent();
    }





    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {

        var result = await _service.Delete(id);



        if(!result)
            return NotFound();



        return NoContent();
    }

}