using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private IClientesAplicacion IClientesAplicacion;

        public ClientesController(IClientesAplicacion IClientesAplicacion)
        {
            this.IClientesAplicacion = IClientesAplicacion;
        }

        [HttpGet]
        public List<Clientes> Consultar()
        {
            return this.IClientesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Clientes> Buscar(Clientes entidad)
        {
            return this.IClientesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Clientes Insertar(Clientes entidad)
        {
            return this.IClientesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Clientes Actualizar(Clientes entidad)
        {
            return this.IClientesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Clientes Borrar(Clientes entidad)
        {
            return this.IClientesAplicacion.Borrar(entidad);
        }


    }
}
