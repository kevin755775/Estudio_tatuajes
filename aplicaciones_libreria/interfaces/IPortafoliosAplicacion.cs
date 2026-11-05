
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface IPortafoliosAplicacion
    {
        Portafolios Insertar(Portafolios entidad);
        Portafolios Actualizar(Portafolios entidad);
        List<Portafolios> Consultar();
        List<Portafolios> Buscar(Portafolios entidad);
        Portafolios Borrar(Portafolios entidad);

    }
}
