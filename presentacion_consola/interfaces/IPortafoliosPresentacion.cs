using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface IPortafoliosPresentacion
    {
        Portafolios Insertar(Portafolios entidad);
        Portafolios Actualizar(Portafolios entidad);
        List<Portafolios> Consultar();
        List<Portafolios> Buscar(Portafolios entidad);
        Portafolios Borrar(Portafolios entidad);
    }
}