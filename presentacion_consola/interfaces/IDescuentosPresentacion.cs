using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface IDescuentosPresentacion
    {
        Descuentos Insertar(Descuentos entidad);
        Descuentos Actualizar(Descuentos entidad);
        List<Descuentos> Consultar();
        List<Descuentos> Buscar(Descuentos entidad);
        Descuentos Borrar(Descuentos entidad);
    }
}