using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface IEstilosTatuajesPresentacion
    {
        EstilosTatuajes Insertar(EstilosTatuajes entidad);
        EstilosTatuajes Actualizar(EstilosTatuajes entidad);
        List<EstilosTatuajes> Consultar();
        List<EstilosTatuajes> Buscar(EstilosTatuajes entidad);
        EstilosTatuajes Borrar(EstilosTatuajes entidad);
    }
}