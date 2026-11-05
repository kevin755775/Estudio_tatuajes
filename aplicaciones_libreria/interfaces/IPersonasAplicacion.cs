
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface IPersonasAplicacion
    {
        Personas Insertar(Personas entidad);
        Personas Actualizar(Personas entidad);
        List<Personas> Consultar();
        List<Personas> Buscar(Personas entidad);
        Personas Borrar(Personas entidad);

    }
}
