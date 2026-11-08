using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface ISedesPresentacion
    {
        Sedes Insertar(Sedes entidad);
        Sedes Actualizar(Sedes entidad);
        List<Sedes> Consultar();
        List<Sedes> Buscar(Sedes entidad);
        Sedes Borrar(Sedes entidad);
    }
}