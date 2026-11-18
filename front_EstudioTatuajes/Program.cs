
using presentacion_consola.implementaciones;
using presentacion_consola.interfaces;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.implementaciones;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddControllers();


builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<ICitasPresentacion, CitasPresentacion>();
builder.Services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
builder.Services.AddScoped<IConsentimientosPresentacion, ConsentimientosPresentacion>();
//builder.Services.AddScoped<ICotizacionesPresentacion, CotizacionesPresentacion>();
//builder.Services.AddScoped<IDescuentosPresentacion, DescuentosPresentacion>();
//builder.Services.AddScoped<IDetallesFacturasPresentacion, DetallesFacturasPresentacion>();
//builder.Services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
//builder.Services.AddScoped<IEstilosTatuajesPresentacion, EstilosTatuajesPresentacion>();
builder.Services.AddScoped<IFacturasPresentacion, FacturasPresentacion>();
//builder.Services.AddScoped<IGastosPresentacion, GastosPresentacion>();
//builder.Services.AddScoped<IImplementosPresentacion, ImplementosPresentacion>();
//builder.Services.AddScoped<IPagosPresentacion, PagosPresentacion>();
//builder.Services.AddScoped<IPersonasPresentacion, PersonasPresentacion>();
//builder.Services.AddScoped<IPortafoliosPresentacion, PortafoliosPresentacion>();
//builder.Services.AddScoped<IProductosVentasPresentacion, ProductosVentasPresentacion>();
//builder.Services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
builder.Services.AddScoped<ISedesPresentacion, SedesPresentacion>();
//builder.Services.AddScoped<ISesionesPresentacion, SesionesPresentacion>();
builder.Services.AddScoped<ITatuadoresPresentacion, TatuadoresPresentacion>();
builder.Services.AddScoped<ITatuajesPresentacion, TatuajesPresentacion>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();