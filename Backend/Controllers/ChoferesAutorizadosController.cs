using Backend.Interfaces;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ChoferesAutorizadosController : ControllerBase
{

    private readonly IChoferesAutorizadosService _service;


    public ChoferesAutorizadosController(
        IChoferesAutorizadosService service)
    {
        _service = service;
    }



    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

}