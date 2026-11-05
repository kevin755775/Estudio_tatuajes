using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_EstudioTatuajes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ConsentimientosController : ControllerBase
    {
        private IConsentimientosAplicacion IConsentimientosAplicacion;

        public ConsentimientosController(IConsentimientosAplicacion IConsentimientosAplicacion)
        {
            this.IConsentimientosAplicacion = IConsentimientosAplicacion;
        }

        [HttpPost]
        public List<Consentimientos> Consultar()
        {
            return this.IConsentimientosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Consentimientos> Buscar(Consentimientos entidad)
        {
            return this.IConsentimientosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Consentimientos Insertar(Consentimientos entidad)
        {
            return this.IConsentimientosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Consentimientos Actualizar(Consentimientos entidad)
        {
            return this.IConsentimientosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Consentimientos Borrar(Consentimientos entidad)
        {
            return this.IConsentimientosAplicacion.Borrar(entidad);
        }


    }
}
