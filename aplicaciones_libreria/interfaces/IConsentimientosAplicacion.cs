
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface IConsentimientosAplicacion
    {
        Consentimientos Insertar(Consentimientos entidad);
        Consentimientos Actualizar(Consentimientos entidad);
        List<Consentimientos> Consultar();
        List<Consentimientos> Buscar(Consentimientos entidad);
        Consentimientos Borrar(Consentimientos entidad);

    }
}
