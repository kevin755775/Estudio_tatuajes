using Aplicaciones_libreria.implementaciones;
using Aplicaciones_libreria.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddOpenApi();

builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<ICitasAplicacion, CitasAplicacion>();


// builder.Services.AddScoped<IentidadAplicacion, entidadAplicacion>();
// builder.Services.AddScoped<IentidadAplicacion, entidadAplicacion>();   para copiar y pegar y tener la inyeccion de dependencias

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "");
app.Run();