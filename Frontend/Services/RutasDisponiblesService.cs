using System.Net.Http.Json;
using Backend.DTO;
using Backend.Models;
using RutasDisponibles = Frontend.Models.RutasDisponibles;

namespace Frontend.Services;

public class RutasDisponiblesService
{
    private readonly HttpClient _http;


    public RutasDisponiblesService(HttpClient http)
    {
        _http = http;
    }
    
    public async Task<List<ParadaMapaDTO>> GetParadasRuta(int idRuta)
    {
        return await _http.GetFromJsonAsync<List<ParadaMapaDTO>>
                   ($"api/RutasDisponibles/paradas/{idRuta}")
               ?? new List<ParadaMapaDTO>();
    }

    public async Task<List<RutasDisponibles>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<RutasDisponibles>>(
            "api/RutasDisponibles"
        ) ?? new();
    }

}