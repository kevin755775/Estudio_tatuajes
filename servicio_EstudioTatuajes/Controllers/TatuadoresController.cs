using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TatuadoresController : ControllerBase
    {
        private ITatuadoresAplicacion ITatuadoresAplicacion;

        public TatuadoresController(ITatuadoresAplicacion ITatuadoresAplicacion)
        {
            this.ITatuadoresAplicacion = ITatuadoresAplicacion;
        }

        [HttpPost]
        public List<Tatuadores> Consultar()
        {
            return this.ITatuadoresAplicacion.Consultar();
        }

        [HttpPost]
        public List<Tatuadores> Buscar(Tatuadores entidad)
        {
            return this.ITatuadoresAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Tatuadores Insertar(Tatuadores entidad)
        {
            return this.ITatuadoresAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Tatuadores Actualizar(Tatuadores entidad)
        {
            return this.ITatuadoresAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Tatuadores Borrar(Tatuadores entidad)
        {
            return this.ITatuadoresAplicacion.Borrar(entidad);
        }


    }
}
