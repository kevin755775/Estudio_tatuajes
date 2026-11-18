using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class ImplementosPresentacion : IImplementosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ImplementosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Implementos Actualizar(Implementos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Implementos>(
                "Implementos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Implementos Borrar(Implementos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Implementos>(
                "Implementos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Implementos> Buscar(Implementos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Implementos>>(
                "Implementos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Implementos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Implementos>>(
                "Implementos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Implementos Insertar(Implementos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Implementos>(
                "Implementos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Implementos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   entidad.Precio <= 0 ||
                   entidad.Proveedores == 0 ||
                   entidad.Sede == 0;
        }
    }
}
