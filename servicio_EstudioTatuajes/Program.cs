using Aplicaciones_libreria.implementaciones;
using Aplicaciones_libreria.interfaces;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddOpenApi();

builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<ICitasAplicacion, CitasAplicacion>();
builder.Services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
//builder.Services.AddScoped<IConsentimientosAplicacion, ConsentimientosAplicacion>();
//builder.Services.AddScoped<ICotizacionesAplicacion, CotizacionesAplicacion>();
//builder.Services.AddScoped<IDescuentosAplicacion, DescuentosAplicacion>();
//builder.Services.AddScoped<IDetallesFacturasAplicacion, DetallesFacturasAplicacion>();
//builder.Services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();
//builder.Services.AddScoped<IEstilosTatuajesAplicacion, EstilosTatuajesAplicacion>();
//builder.Services.AddScoped<IFacturasAplicacion, FacturasAplicacion>();
//builder.Services.AddScoped<IGastosAplicacion, GastosAplicacion>();
//builder.Services.AddScoped<IImplementosAplicacion, ImplementosAplicacion>();
//builder.Services.AddScoped<IPagosAplicacion, PagosAplicacion>();
//builder.Services.AddScoped<IPersonasAplicacion, PersonasAplicacion>();
//builder.Services.AddScoped<IPortafoliosAplicacion, PortafoliosAplicacion>();
//builder.Services.AddScoped<IProductosVentasAplicacion, ProductosVentasAplicacion>();
//builder.Services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
//builder.Services.AddScoped<ISedesAplicacion, SedesAplicacion>();
//builder.Services.AddScoped<ISesionesAplicacion, SesionesAplicacion>();
//builder.Services.AddScoped<ITatuadoresAplicacion, TatuadoresAplicacion>();
//builder.Services.AddScoped<ITatuajesAplicacion, TatuajesAplicacion>();



//builder.Services.AddScoped<IAplicacion, Aplicacion>();
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