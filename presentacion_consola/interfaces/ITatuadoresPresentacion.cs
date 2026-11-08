using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface ITatuadoresPresentacion
    {
        Tatuadores Insertar(Tatuadores entidad);
        Tatuadores Actualizar(Tatuadores entidad);
        List<Tatuadores> Consultar();
        List<Tatuadores> Buscar(Tatuadores entidad);
        Tatuadores Borrar(Tatuadores entidad);
    }
}