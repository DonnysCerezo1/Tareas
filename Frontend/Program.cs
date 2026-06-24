using Frontend.Components;
using Frontend.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(" http://localhost:5120/")
    });
    

builder.Services.AddScoped<EstudianteService>();
builder.Services.AddScoped<ChoferesAutorizadosService>();
builder.Services.AddScoped<VehiculosService>();
builder.Services.AddScoped<RutasDisponiblesService>();
builder.Services.AddScoped<HorariosService>();
builder.Services.AddScoped<ReservasService>();



var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();