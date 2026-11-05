
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface IDescuentosAplicacion
    {
        Descuentos Insertar(Descuentos entidad);
        Descuentos Actualizar(Descuentos entidad);
        List<Descuentos> Consultar();
        List<Descuentos> Buscar(Descuentos entidad);
        Descuentos Borrar(Descuentos entidad);

    }
}
