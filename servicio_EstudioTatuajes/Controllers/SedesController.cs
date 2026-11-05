using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SedesController : ControllerBase
    {
        private ISedesAplicacion ISedesAplicacion;

        public SedesController(ISedesAplicacion ISedesAplicacion)
        {
            this.ISedesAplicacion = ISedesAplicacion;
        }

        [HttpPost]
        public List<Sedes> Consultar()
        {
            return this.ISedesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Sedes> Buscar(Sedes entidad)
        {
            return this.ISedesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Sedes Insertar(Sedes entidad)
        {
            return this.ISedesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Sedes Actualizar(Sedes entidad)
        {
            return this.ISedesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Sedes Borrar(Sedes entidad)
        {
            return this.ISedesAplicacion.Borrar(entidad);
        }


    }
}
