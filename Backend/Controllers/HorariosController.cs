using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class HorariosController : ControllerBase
{

    private readonly IHorariosService _service;


    public HorariosController(
        IHorariosService service)
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

        var horario = await _service.GetById(id);



        if(horario == null)
            return NotFound();



        return Ok(horario);
    }





    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] Horarios horario)
    {

        var result = await _service.Create(horario);


        return Ok(result);
    }





    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] Horarios horario)
    {

        var result = await _service.Update(id, horario);



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