using Aplicaciones_libreria.entidades;

namespace Aplicaciones_libreria.interfaces
{
    public interface IProductosVentasPresentacion
    {
        ProductosVentas Insertar(ProductosVentas entidad);
        ProductosVentas Actualizar(ProductosVentas entidad);
        List<ProductosVentas> Consultar();
        List<ProductosVentas> Buscar(ProductosVentas entidad);
        ProductosVentas Borrar(ProductosVentas entidad);
    }
}