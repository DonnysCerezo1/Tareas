using Backend.Interfaces;
using Backend.Services;
using Backend.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IAristaService, AristaService>();
builder.Services.AddScoped<INodoService, NodoService>();
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
    
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();
