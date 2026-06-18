using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VehiculoController : ControllerBase
{

    private readonly IVehiculoService _service;



    public VehiculoController(
        IVehiculoService service)
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

        var vehiculo = await _service.GetById(id);


        if(vehiculo == null)
            return NotFound();


        return Ok(vehiculo);
    }






    [HttpPost]
    public async Task<IActionResult> Create(
        Vehiculos vehiculo)
    {

        var result = await _service.Create(vehiculo);


        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        Vehiculos vehiculo)
    {
        var result = await _service.Update(id, vehiculo);


        if(result == null)
            return NotFound();


        return NoContent();
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.Delete(id);


        if(result == null)
            return NotFound();


        return NoContent();
    }

}