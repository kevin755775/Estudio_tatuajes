using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class TatuadoresPresentacion : ITatuadoresPresentacion
    {
        private IComunicaciones IComunicaciones;

        public TatuadoresPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Tatuadores Actualizar(Tatuadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Tatuadores>(
                "Tatuadores/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Tatuadores Borrar(Tatuadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Tatuadores>(
                "Tatuadores/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Tatuadores> Buscar(Tatuadores entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Tatuadores>>(
                "Tatuadores/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Tatuadores> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Tatuadores>>(
                "Tatuadores/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Tatuadores Insertar(Tatuadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Tatuadores>(
                "Tatuadores/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Tatuadores entidad)
        {
            return string.IsNullOrEmpty(entidad.Licencia) ||
                  entidad.Portafolio == 0 ||
                  entidad.Persona == 0 ||
                  entidad.Sede == 0;
        }
    }
}