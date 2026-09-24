using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

try
{
    IConexion conexion = new Conexion();
   
    conexion.StringConexion = "server=localhost;database=estudio_tatuajes_db;Integrated Security=True;TrustServerCertificate=true;";

    
    var lista_personas = conexion.Personas!.ToList();

    
    var lista_clientes = conexion.Clientes!
        .Include(x => x._Persona)
        .ToList();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("presentacion_consola");
