using System.Net.Http.Json;
using Frontend.Models;

namespace Frontend.Services;

public class ReservasService
{
    private readonly HttpClient _http;

    public ReservasService(HttpClient http)
    {
        _http = http;
    }


    public async Task Crear(Reservas reserva)
    {
        var respuesta = await _http.PostAsJsonAsync(
            "api/Reservas",
            reserva
        );

        respuesta.EnsureSuccessStatusCode();
    }


    public async Task<List<ReservaDTO>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<ReservaDTO>>(
            "api/Reservas"
        ) ?? new();
    }
}