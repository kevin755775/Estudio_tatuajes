using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ImplementosController : ControllerBase
    {
        private IImplementosAplicacion IImplementosAplicacion;

        public ImplementosController(IImplementosAplicacion IImplementosAplicacion)
        {
            this.IImplementosAplicacion = IImplementosAplicacion;
        }

        [HttpPost]
        public List<Implementos> Consultar()
        {
            return this.IImplementosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Implementos> Buscar(Implementos entidad)
        {
            return this.IImplementosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Implementos Insertar(Implementos entidad)
        {
            return this.IImplementosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Implementos Actualizar(Implementos entidad)
        {
            return this.IImplementosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Implementos Borrar(Implementos entidad)
        {
            return this.IImplementosAplicacion.Borrar(entidad);
        }


    }
}
