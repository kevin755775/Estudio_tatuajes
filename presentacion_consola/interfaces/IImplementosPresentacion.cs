using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface IImplementosPresentacion
    {
        Implementos Insertar(Implementos entidad);
        Implementos Actualizar(Implementos entidad);
        List<Implementos> Consultar();
        List<Implementos> Buscar(Implementos entidad);
        Implementos Borrar(Implementos entidad);
    }
}