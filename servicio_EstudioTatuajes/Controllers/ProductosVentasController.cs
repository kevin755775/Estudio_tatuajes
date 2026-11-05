using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductosVentasController : ControllerBase
    {
        private IProductosVentasAplicacion IProductosVentasAplicacion;

        public ProductosVentasController(IProductosVentasAplicacion IProductosVentasAplicacion)
        {
            this.IProductosVentasAplicacion = IProductosVentasAplicacion;
        }

        [HttpPost]
        public List<ProductosVentas> Consultar()
        {
            return this.IProductosVentasAplicacion.Consultar();
        }

        [HttpPost]
        public List<ProductosVentas> Buscar(ProductosVentas entidad)
        {
            return this.IProductosVentasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public ProductosVentas Insertar(ProductosVentas entidad)
        {
            return this.IProductosVentasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public ProductosVentas Actualizar(ProductosVentas entidad)
        {
            return this.IProductosVentasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public ProductosVentas Borrar(ProductosVentas entidad)
        {
            return this.IProductosVentasAplicacion.Borrar(entidad);
        }


    }
}
