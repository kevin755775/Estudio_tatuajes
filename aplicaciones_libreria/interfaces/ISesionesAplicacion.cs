
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface ISesionesAplicacion
    {
        Sesiones Insertar(Sesiones entidad);
        Sesiones Actualizar(Sesiones entidad);
        List<Sesiones> Consultar();
        List<Sesiones> Buscar(Sesiones entidad);
        Sesiones Borrar(Sesiones entidad);

    }
}
