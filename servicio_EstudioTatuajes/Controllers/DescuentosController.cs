using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DescuentosController : ControllerBase
    {
        private IDescuentosAplicacion IDescuentosAplicacion;

        public DescuentosController(IDescuentosAplicacion IDescuentosAplicacion)
        {
            this.IDescuentosAplicacion = IDescuentosAplicacion;
        }

        [HttpPost]
        public List<Descuentos> Consultar()
        {
            return this.IDescuentosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Descuentos> Buscar(Descuentos entidad)
        {
            return this.IDescuentosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Descuentos Insertar(Descuentos entidad)
        {
            return this.IDescuentosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Descuentos Actualizar(Descuentos entidad)
        {
            return this.IDescuentosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Descuentos Borrar(Descuentos entidad)
        {
            return this.IDescuentosAplicacion.Borrar(entidad);
        }


    }
}
