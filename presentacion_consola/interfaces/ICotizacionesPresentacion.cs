using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface ICotizacionesPresentacion
    {
        Cotizaciones Insertar(Cotizaciones entidad);
        Cotizaciones Actualizar(Cotizaciones entidad);
        List<Cotizaciones> Consultar();
        List<Cotizaciones> Buscar(Cotizaciones entidad);
        Cotizaciones Borrar(Cotizaciones entidad);
    }
}