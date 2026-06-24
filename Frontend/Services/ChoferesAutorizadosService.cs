using System.Net.Http.Json;
using Backend.Models;


namespace Frontend.Services;


public class ChoferesAutorizadosService
{

    private readonly HttpClient _http;


    public ChoferesAutorizadosService(HttpClient http)
    {
        _http = http;
    }



    public async Task<List<ChoferesAutorizados>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<ChoferesAutorizados>>
                   ("api/ChoferesAutorizados")
               ?? new();
    }

}