using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class TatuajesPresentacion : ITatuajesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public TatuajesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Tatuajes Actualizar(Tatuajes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Tatuajes>(
                "Tatuajes/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Tatuajes Borrar(Tatuajes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Tatuajes>(
                "Tatuajes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Tatuajes> Buscar(Tatuajes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Tatuajes>>(
                "Tatuajes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Tatuajes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Tatuajes>>(
                "Tatuajes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Tatuajes Insertar(Tatuajes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Tatuajes>(
                "Tatuajes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Tatuajes entidad)
        {
            return string.IsNullOrEmpty(entidad.ZonaCuerpo) ||
                   entidad.Ancho <= 0 ||
                   entidad.Alto <= 0 ||
                   entidad.EstiloTatuaje == 0;
        }
    }
}
