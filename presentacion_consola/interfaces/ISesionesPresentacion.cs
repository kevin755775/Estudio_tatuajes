using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface ISesionesPresentacion
    {
        Sesiones Insertar(Sesiones entidad);
        Sesiones Actualizar(Sesiones entidad);
        List<Sesiones> Consultar();
        List<Sesiones> Buscar(Sesiones entidad);
        Sesiones Borrar(Sesiones entidad);
    }
}