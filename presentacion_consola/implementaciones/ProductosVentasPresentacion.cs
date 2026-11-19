using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class ProductosVentasPresentacion : IProductosVentasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ProductosVentasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public ProductosVentas Actualizar(ProductosVentas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<ProductosVentas>(
                "ProductosVentas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public ProductosVentas Borrar(ProductosVentas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<ProductosVentas>(
                "ProductosVentas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<ProductosVentas> Buscar(ProductosVentas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<ProductosVentas>>(
                "ProductosVentas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<ProductosVentas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<ProductosVentas>>(
                "ProductosVentas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public ProductosVentas Insertar(ProductosVentas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<ProductosVentas>(
                "ProductosVentas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(ProductosVentas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Marca) ||
                   entidad.Precio <= 0 ||
                   entidad.Proveedores == 0 ||
                   entidad.Sede == 0;
        }
    }
}
