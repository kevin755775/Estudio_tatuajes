using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.implementaciones
{
    public class RolesAplicacion : IRolesAplicacion
    {
        private IConexion IConexion;

        public RolesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Roles Actualizar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.Auditorias!.Add(
                new Auditorias()
                {
                    Entidad = "Roles",
                    Accion = "Actualizar",
                    Descripcion = "Se actualizo un Rol",
                    Fecha = DateTime.Now
                });
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Roles!.Remove(entidad!);
            this.IConexion.Auditorias!.Add(
                new Auditorias()
                {
                    Entidad = "Roles",
                    Accion = "Borrar",
                    Descripcion = "Se borro un Rol",
                    Fecha = DateTime.Now
                });
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Roles> Buscar(Roles entidad)
        {
            return this.IConexion.Roles!
                .Where(x => x.Tipo != null && x.Tipo.Contains(entidad.Tipo ?? ""))
                .ToList();
        }

        public List<Roles> Consultar()
        {
            return this.IConexion.Roles!.ToList();
        }

        public Roles Insertar(Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Roles!.Add(entidad!);
            this.IConexion.Auditorias!.Add(
                new Auditorias()
                {
                    Entidad = "Roles",
                    Accion = "Insertar",
                    Descripcion = "Se inserto un Rol",
                    Fecha = DateTime.Now
                });
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Roles entidad)
        {
            return string.IsNullOrEmpty(entidad.Tipo) ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
