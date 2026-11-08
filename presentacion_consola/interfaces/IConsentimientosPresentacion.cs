using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface IConsentimientosPresentacion
    {
        Consentimientos Insertar(Consentimientos entidad);
        Consentimientos Actualizar(Consentimientos entidad);
        List<Consentimientos> Consultar();
        List<Consentimientos> Buscar(Consentimientos entidad);
        Consentimientos Borrar(Consentimientos entidad);
    }
}