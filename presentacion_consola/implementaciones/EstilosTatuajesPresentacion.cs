using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class EstilosTatuajesPresentacion : IEstilosTatuajesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public EstilosTatuajesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public EstilosTatuajes Actualizar(EstilosTatuajes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<EstilosTatuajes>(
                "EstilosTatuajes/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public EstilosTatuajes Borrar(EstilosTatuajes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<EstilosTatuajes>(
                "EstilosTatuajes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<EstilosTatuajes> Buscar(EstilosTatuajes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<EstilosTatuajes>>(
                "EstilosTatuajes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<EstilosTatuajes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<EstilosTatuajes>>(
                "EstilosTatuajes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public EstilosTatuajes Insertar(EstilosTatuajes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<EstilosTatuajes>(
                "EstilosTatuajes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(EstilosTatuajes entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   string.IsNullOrEmpty(entidad.NivelDificultad);
        }
    }
}
