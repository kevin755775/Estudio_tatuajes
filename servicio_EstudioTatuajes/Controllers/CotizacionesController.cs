using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CotizacionesController : ControllerBase
    {
        private ICotizacionesAplicacion ICotizacionesAplicacion;

        public CotizacionesController(ICotizacionesAplicacion ICotizacionesAplicacion)
        {
            this.ICotizacionesAplicacion = ICotizacionesAplicacion;
        }

        [HttpPost]
        public List<Cotizaciones> Consultar()
        {
            return this.ICotizacionesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Cotizaciones> Buscar(Cotizaciones entidad)
        {
            return this.ICotizacionesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Cotizaciones Insertar(Cotizaciones entidad)
        {
            return this.ICotizacionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Cotizaciones Actualizar(Cotizaciones entidad)
        {
            return this.ICotizacionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Cotizaciones Borrar(Cotizaciones entidad)
        {
            return this.ICotizacionesAplicacion.Borrar(entidad);
        }


    }
}
