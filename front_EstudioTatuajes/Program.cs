using Aplicaciones_libreria.implementaciones;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.implementaciones;
using presentacion_consola.interfaces;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddControllers();


builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<ICitasPresentacion, CitasPresentacion>();

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