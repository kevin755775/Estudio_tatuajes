using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TatuajesController : ControllerBase
    {
        private ITatuajesAplicacion ITatuajesAplicacion;

        public TatuajesController(ITatuajesAplicacion ITatuajesAplicacion)
        {
            this.ITatuajesAplicacion = ITatuajesAplicacion;
        }

        [HttpPost]
        public List<Tatuajes> Consultar()
        {
            return this.ITatuajesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Tatuajes> Buscar(Tatuajes entidad)
        {
            return this.ITatuajesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Tatuajes Insertar(Tatuajes entidad)
        {
            return this.ITatuajesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Tatuajes Actualizar(Tatuajes entidad)
        {
            return this.ITatuajesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Tatuajes Borrar(Tatuajes entidad)
        {
            return this.ITatuajesAplicacion.Borrar(entidad);
        }


    }
}
