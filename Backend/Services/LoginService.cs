using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class LoginService
{
    private readonly AppDbContext _context;


    public LoginService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuarios?> Login(
        string correo,
        string password)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(x =>
                x.Correo == correo &&
                x.PasswordHash == password &&
                x.Estado);
    }
}