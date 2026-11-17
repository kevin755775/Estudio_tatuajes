using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class SedesPresentacion : ISedesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public SedesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Sedes Actualizar(Sedes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Sedes>(
                "Sedes/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Sedes Borrar(Sedes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Sedes>(
                "Sedes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Sedes> Buscar(Sedes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Sedes>>(
                "Sedes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Sedes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Sedes>>(
                "Sedes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Sedes Insertar(Sedes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Sedes>(
                "Sedes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Sedes entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   string.IsNullOrEmpty(entidad.Ciudad);
        }
    }
}