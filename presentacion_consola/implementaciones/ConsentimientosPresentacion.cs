using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class ConsentimientosPresentacion : IConsentimientosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ConsentimientosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Consentimientos Actualizar(Consentimientos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Consentimientos>(
                "Consentimientos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Consentimientos Borrar(Consentimientos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Consentimientos>(
                "Consentimientos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Consentimientos> Buscar(Consentimientos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Consentimientos>>(
                "Consentimientos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Consentimientos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Consentimientos>>(
                "Consentimientos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Consentimientos Insertar(Consentimientos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Consentimientos>(
                "Consentimientos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Consentimientos entidad)
        {
            return string.IsNullOrEmpty(entidad.Observaciones);
        }
    }
}