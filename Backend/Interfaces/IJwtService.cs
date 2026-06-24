using Backend.Models;

namespace Backend.Interfaces;
public interface IJwtService
{
    string GenerarToken(Usuarios usuario);
}