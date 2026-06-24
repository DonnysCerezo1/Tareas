using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Usuarios
{
    [Key]
    public int IDUsuario { get; set; }

    public string Usuario { get; set; } = string.Empty;
    
    public string Correo  { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Rol { get; set; } = string.Empty;

    public int? IDReferencia { get; set; }

    public bool Estado { get; set; }
}