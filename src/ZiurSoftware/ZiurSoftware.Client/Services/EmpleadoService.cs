using System.Net.Http.Json;
using ZiurSoftware.Client.Models;


namespace ZiurSoftware.Client.Services;

public class EmpleadoService : IEmpleadoService
{
    private readonly HttpClient _http;

    public EmpleadoService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Empleado>> GetAllAsync()
    {
        var result = await _http.GetFromJsonAsync<List<Empleado>>("DocumentosFillsCombos");
        return result ?? [];
    }
}