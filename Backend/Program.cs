using Backend.Interfaces;
using Backend.Services;
using Backend.Data;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IAristaService, AristaService>();
builder.Services.AddScoped<INodoService, NodoService>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IChoferesAutorizadosService, ChoferesAutorizadosService>();
builder.Services.AddScoped<IRutasDisponiblesService, RutasDisponiblesService>();
builder.Services.AddScoped<IReservasService, ReservasService>();
builder.Services.AddScoped<IHistorialViajesService, HistorialViajesService>();
builder.Services.AddScoped<ICalificacionServicioService, CalificacionServicioService>();
builder.Services.AddScoped<IHorariosService, HorariosService>();


var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");


Console.WriteLine("=================================");
Console.WriteLine(connectionString);
Console.WriteLine("=================================");


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(10, 11, 0))
    );
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins("https://donjortech.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Como estás usando HTTP en desarrollo puedes comentar esto
// app.UseHttpsRedirection();


app.UseRouting();
app.UseCors("publico");
app.MapControllers();


app.Run();