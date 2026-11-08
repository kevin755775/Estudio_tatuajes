using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface ITatuajesPresentacion
    {
        Tatuajes Insertar(Tatuajes entidad);
        Tatuajes Actualizar(Tatuajes entidad);
        List<Tatuajes> Consultar();
        List<Tatuajes> Buscar(Tatuajes entidad);
        Tatuajes Borrar(Tatuajes entidad);
    }
}