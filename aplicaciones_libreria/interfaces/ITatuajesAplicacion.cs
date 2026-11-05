
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface ITatuajesAplicacion
    {
        Tatuajes Insertar(Tatuajes entidad);
        Tatuajes Actualizar(Tatuajes entidad);
        List<Tatuajes> Consultar();
        List<Tatuajes> Buscar(Tatuajes entidad);
        Tatuajes Borrar(Tatuajes entidad);

    }
}
