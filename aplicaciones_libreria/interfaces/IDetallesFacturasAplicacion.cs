
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface IDetallesFacturasAplicacion
    {
        DetallesFacturas Insertar(DetallesFacturas entidad);
        DetallesFacturas Actualizar(DetallesFacturas entidad);
        List<DetallesFacturas> Consultar();
        List<DetallesFacturas> Buscar(DetallesFacturas entidad);
        DetallesFacturas Borrar(DetallesFacturas entidad);

    }
}
