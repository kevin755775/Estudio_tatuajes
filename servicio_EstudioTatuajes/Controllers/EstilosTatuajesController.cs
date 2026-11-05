using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EstilosTatuajesController : ControllerBase
    {
        private IEstilosTatuajesAplicacion IEstilosTatuajesAplicacion;

        public EstilosTatuajesController(IEstilosTatuajesAplicacion IEstilosTatuajesAplicacion)
        {
            this.IEstilosTatuajesAplicacion = IEstilosTatuajesAplicacion;
        }

        [HttpPost]
        public List<EstilosTatuajes> Consultar()
        {
            return this.IEstilosTatuajesAplicacion.Consultar();
        }

        [HttpPost]
        public List<EstilosTatuajes> Buscar(EstilosTatuajes entidad)
        {
            return this.IEstilosTatuajesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public EstilosTatuajes Insertar(EstilosTatuajes entidad)
        {
            return this.IEstilosTatuajesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public EstilosTatuajes Actualizar(EstilosTatuajes entidad)
        {
            return this.IEstilosTatuajesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public EstilosTatuajes Borrar(EstilosTatuajes entidad)
        {
            return this.IEstilosTatuajesAplicacion.Borrar(entidad);
        }


    }
}
