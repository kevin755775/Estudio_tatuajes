using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface IDetallesFacturasPresentacion
    {
        DetallesFacturas Insertar(DetallesFacturas entidad);
        DetallesFacturas Actualizar(DetallesFacturas entidad);
        List<DetallesFacturas> Consultar();
        List<DetallesFacturas> Buscar(DetallesFacturas entidad);
        DetallesFacturas Borrar(DetallesFacturas entidad);
    }
}