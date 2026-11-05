using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PortafoliosController : ControllerBase
    {
        private IPortafoliosAplicacion IPortafoliosAplicacion;

        public PortafoliosController(IPortafoliosAplicacion IPortafoliosAplicacion)
        {
            this.IPortafoliosAplicacion = IPortafoliosAplicacion;
        }

        [HttpPost]
        public List<Portafolios> Consultar()
        {
            return this.IPortafoliosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Portafolios> Buscar(Portafolios entidad)
        {
            return this.IPortafoliosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Portafolios Insertar(Portafolios entidad)
        {
            return this.IPortafoliosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Portafolios Actualizar(Portafolios entidad)
        {
            return this.IPortafoliosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Portafolios Borrar(Portafolios entidad)
        {
            return this.IPortafoliosAplicacion.Borrar(entidad);
        }


    }
}
