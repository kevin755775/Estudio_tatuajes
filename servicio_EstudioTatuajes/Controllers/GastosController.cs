using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GastosController : ControllerBase
    {
        private IGastosAplicacion IGastosAplicacion;

        public GastosController(IGastosAplicacion IGastosAplicacion)
        {
            this.IGastosAplicacion = IGastosAplicacion;
        }

        [HttpPost]
        public List<Gastos> Consultar()
        {
            return this.IGastosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Gastos> Buscar(Gastos entidad)
        {
            return this.IGastosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Gastos Insertar(Gastos entidad)
        {
            return this.IGastosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Gastos Actualizar(Gastos entidad)
        {
            return this.IGastosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Gastos Borrar(Gastos entidad)
        {
            return this.IGastosAplicacion.Borrar(entidad);
        }


    }
}
