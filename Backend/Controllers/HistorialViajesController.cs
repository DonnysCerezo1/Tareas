using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class HistorialViajesController : ControllerBase
{

    private readonly IHistorialViajesService _service;


    public HistorialViajesController(
        IHistorialViajesService service)
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

        var historial = await _service.GetById(id);



        if(historial == null)
            return NotFound();



        return Ok(historial);
    }





    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] HistorialViajes historial)
    {

        var result = await _service.Create(historial);


        return Ok(result);
    }





    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] HistorialViajes historial)
    {

        var result = await _service.Update(id, historial);



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