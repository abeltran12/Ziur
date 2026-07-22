using ZiurSoftware.Client.Models;

namespace ZiurSoftware.Client.Services;

public interface IEmpleadoService
{
    Task<List<Empleado>> GetAllAsync();
}