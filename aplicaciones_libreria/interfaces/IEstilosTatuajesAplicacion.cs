
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface IEstilosTatuajesAplicacion
    {
        EstilosTatuajes Insertar(EstilosTatuajes entidad);
        EstilosTatuajes Actualizar(EstilosTatuajes entidad);
        List<EstilosTatuajes> Consultar();
        List<EstilosTatuajes> Buscar(EstilosTatuajes entidad);
        EstilosTatuajes Borrar(EstilosTatuajes entidad);

    }
}
