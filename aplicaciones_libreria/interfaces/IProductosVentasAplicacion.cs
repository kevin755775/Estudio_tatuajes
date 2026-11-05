
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface IProductosVentasAplicacion
    {
        ProductosVentas Insertar(ProductosVentas entidad);
        ProductosVentas Actualizar(ProductosVentas entidad);
        List<ProductosVentas> Consultar();
        List<ProductosVentas> Buscar(ProductosVentas entidad);
        ProductosVentas Borrar(ProductosVentas entidad);

    }
}
