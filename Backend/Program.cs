using Backend.Interfaces;
using Backend.Services;

var Builder = WebApplication.CreateBuilder(args);
Builder.Services.AddControllers();
Builder.Services.AddScoped<IAristaService, AristaService>();
    
var app = Builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();
