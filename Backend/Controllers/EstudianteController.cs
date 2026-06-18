using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class EstudianteController : ControllerBase
{

    private readonly IEstudianteService _service;


    public EstudianteController(
        IEstudianteService service)
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
        var estudiante = await _service.GetById(id);


        if(estudiante == null)
            return NotFound();


        return Ok(estudiante);
    }



    [HttpPost]
    public async Task<IActionResult> Create(
        Estudiantes estudiante)
    {
        var result = await _service.Create(estudiante);

        return Ok(result);
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        Estudiantes estudiante)
    {

        var result = await _service.Update(id, estudiante);


        if(!result)
            return NotFound();


        return NoContent();
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}