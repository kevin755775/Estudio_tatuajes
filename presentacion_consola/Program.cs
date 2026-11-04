using Aplicaciones_libreria.nucleo;
using Aplicaciones_libreria.implementaciones;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

try
{
    IConexion conexion = new Conexion();
   
    conexion.StringConexion = Datosgenerales.ObtenerStringConexion();


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
