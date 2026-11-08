using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface IGastosPresentacion
    {
        Gastos Insertar(Gastos entidad);
        Gastos Actualizar(Gastos entidad);
        List<Gastos> Consultar();
        List<Gastos> Buscar(Gastos entidad);
        Gastos Borrar(Gastos entidad);
    }
}