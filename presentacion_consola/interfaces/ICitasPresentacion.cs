using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface ICitasPresentacion
    {
        Citas Insertar(Citas entidad);
        Citas Actualizar(Citas entidad);
        List<Citas> Consultar();
        List<Citas> Buscar(Citas entidad);
        Citas Borrar(Citas entidad);
    }
}