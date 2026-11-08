using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class EmpleadosPresentacion : IEmpleadosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public EmpleadosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Empleados Actualizar(Empleados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Empleados>(
                "Empleados/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Empleados Borrar(Empleados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Empleados>(
                "Empleados/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Empleados> Buscar(Empleados entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Empleados>>(
                "Empleados/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Empleados> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Empleados>>(
                "Empleados/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Empleados Insertar(Empleados entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Empleados>(
                "Empleados/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Empleados entidad)
        {
            return string.IsNullOrEmpty(entidad.Cargo) ||
                   entidad.Salario <= 0 ||
                   entidad.Sede == 0 ||
                   entidad.Persona == 0;
        }
    }
}