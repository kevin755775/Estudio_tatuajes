
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface IImplementosAplicacion
    {
        Implementos Insertar(Implementos entidad);
        Implementos Actualizar(Implementos entidad);
        List<Implementos> Consultar();
        List<Implementos> Buscar(Implementos entidad);
        Implementos Borrar(Implementos entidad);

    }
}
