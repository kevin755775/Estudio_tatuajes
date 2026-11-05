
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface ITatuadoresAplicacion
    {
        Tatuadores Insertar(Tatuadores entidad);
        Tatuadores Actualizar(Tatuadores entidad);
        List<Tatuadores> Consultar();
        List<Tatuadores> Buscar(Tatuadores entidad);
        Tatuadores Borrar(Tatuadores entidad);

    }
}
