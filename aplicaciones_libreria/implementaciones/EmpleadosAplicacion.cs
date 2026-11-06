using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;


namespace Aplicaciones_libreria.implementaciones
{
    public class EmpleadosAplicacion : IEmpleadosAplicacion
    {
        private IConexion IConexion;

        public EmpleadosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Empleados Actualizar(Empleados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Empleados Borrar(Empleados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Empleados!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Empleados> Buscar(Empleados entidad)
        {
            return this.IConexion.Empleados!
                .Include(x => x._Sede)
                .Include(x => x._Persona)
                .Where(x => x.Sede == entidad.Sede)
                .ToList();
        }

        public List<Empleados> Consultar()
        {
            return this.IConexion.Empleados!
                .Include(x => x._Sede)
                .Include(x => x._Persona)
                .Take(5)
                .ToList();
        }

        public Empleados Insertar(Empleados entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Empleados!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
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