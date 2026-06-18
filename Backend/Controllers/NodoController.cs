using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class NodosController : ControllerBase
{

    private readonly INodoService _service;



    public NodosController(INodoService service)
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

        var nodo = await _service.GetById(id);


        if(nodo == null)
            return NotFound();


        return Ok(nodo);
    }





    [HttpPost]
    public async Task<IActionResult> Create(Nodos nodo)
    {

        var result = await _service.Create(nodo);


        return Ok(result);
    }





    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        Nodos nodo)
    {

        var result = await _service.Update(id, nodo);


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