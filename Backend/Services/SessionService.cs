using Backend.Models;

namespace Backend.Services;

public class SessionService
{
    public class SesionService
    {
        public Usuarios? UsuarioActual { get; set; }

        public bool Logueado =>
            UsuarioActual != null;
    }
}