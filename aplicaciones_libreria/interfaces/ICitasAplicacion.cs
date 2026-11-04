
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface ICitasAplicacion
    {
        Citas Insertar(Citas entidad);
        Citas Actualizar(Citas entidad);
        List<Citas> Consultar();
        List<Citas> Buscar(Citas entidad);
        Citas Borrar(Citas entidad);

    }
}
