
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface ICotizacionesAplicacion
    {
        Cotizaciones Insertar(Cotizaciones entidad);
        Cotizaciones Actualizar(Cotizaciones entidad);
        List<Cotizaciones> Consultar();
        List<Cotizaciones> Buscar(Cotizaciones entidad);
        Cotizaciones Borrar(Cotizaciones entidad);

    }
}
