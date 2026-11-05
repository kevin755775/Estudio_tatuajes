using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SesionesController : ControllerBase
    {
        private ISesionesAplicacion ISesionesAplicacion;

        public SesionesController(ISesionesAplicacion ISesionesAplicacion)
        {
            this.ISesionesAplicacion = ISesionesAplicacion;
        }

        [HttpPost]
        public List<Sesiones> Consultar()
        {
            return this.ISesionesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Sesiones> Buscar(Sesiones entidad)
        {
            return this.ISesionesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Sesiones Insertar(Sesiones entidad)
        {
            return this.ISesionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Sesiones Actualizar(Sesiones entidad)
        {
            return this.ISesionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Sesiones Borrar(Sesiones entidad)
        {
            return this.ISesionesAplicacion.Borrar(entidad);
        }


    }
}
