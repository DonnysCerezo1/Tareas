using System.Net.Http.Json;
using Backend.Models;

namespace Frontend.Services;

public class EstudianteService
{
    private readonly HttpClient _http;

    public EstudianteService(HttpClient http)
    {
        _http = http;
    }


    public async Task<List<Estudiantes>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<Estudiantes>>
                   ("api/Estudiante")
               ?? new();
    }


    public async Task<Estudiantes?> Create(Estudiantes estudiante)
    {
        var response = await _http.PostAsJsonAsync(
            "api/Estudiante",
            estudiante);

        return await response.Content.ReadFromJsonAsync<Estudiantes>();
    }
}