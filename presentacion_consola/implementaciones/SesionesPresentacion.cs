using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class SesionesPresentacion : ISesionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public SesionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Sesiones Actualizar(Sesiones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Sesiones>(
                "Sesiones/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Sesiones Borrar(Sesiones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Sesiones>(
                "Sesiones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Sesiones> Buscar(Sesiones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Sesiones>>(
                "Sesiones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Sesiones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Sesiones>>(
                "Sesiones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Sesiones Insertar(Sesiones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Sesiones>(
                "Sesiones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Sesiones entidad)
        {
            return entidad.NroSesion <= 0 ||
                   entidad.DuracionHrs <= 0 ||
                   entidad.Tatuaje == 0;
        }
    }
}
