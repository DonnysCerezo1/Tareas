using System.Net.Http.Json;
using Frontend.Models;

namespace Frontend.Services;

public class HorariosService
{
    private readonly HttpClient _http;

    public HorariosService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<HorarioDTO>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<HorarioDTO>>
        (
            "api/Horarios"
        ) ?? new();
    }
}