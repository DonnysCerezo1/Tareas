using System.Net.Http.Json;
using Backend.Models;

namespace Frontend.Services;

public class VehiculosService
{
    private readonly HttpClient _http;

    public VehiculosService(HttpClient http)
    {
        _http = http;
    }


    public async Task<List<Vehiculos>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<Vehiculos>>
                   ("api/Vehiculo")
               ?? new();
    }
}