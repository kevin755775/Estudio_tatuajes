using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion IConexion;

        public UsuariosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Usuarios Actualizar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            if (this.IConexion.Usuarios!.Any(x => x.Email == entidad.Email && x.Id != entidad.Id))
                throw new Exception("El email ya existe");

            var entry = this.IConexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;

            
            if (string.IsNullOrEmpty(entidad.Clave))
                entry.Property(x => x.Clave).IsModified = false;

            this.IConexion.Auditorias!.Add(
                new Auditorias()
                {
                    Entidad = "Usuarios",
                    Accion = "Actualizar",
                    Descripcion = "Se actualizo un Usuario",
                    Fecha = DateTime.Now
                });
            this.IConexion!.SaveChanges();
            entidad.Clave = null;
            return entidad;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Usuarios!.Remove(entidad!);
            this.IConexion.Auditorias!.Add(
                new Auditorias()
                {
                    Entidad = "Usuarios",
                    Accion = "Borrar",
                    Descripcion = "Se borro un Usuario",
                    Fecha = DateTime.Now
                });
            this.IConexion.SaveChanges();
            entidad.Clave = null;
            return entidad;
        }

        public List<Usuarios> Buscar(Usuarios entidad)
        {
            var lista = this.IConexion.Usuarios!
                .Include(x => x._Rol)
                .Include(x => x._Persona)
                .Where(x => x.Email != null && x.Email.Contains(entidad.Email ?? ""))
                .ToList();
            return SinClaves(lista);
        }

        public List<Usuarios> Consultar()
        {
            var lista = this.IConexion.Usuarios!
                .Include(x => x._Rol)
                .Include(x => x._Persona)
                .ToList();
            return SinClaves(lista);
        }

        public Usuarios Insertar(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad) || string.IsNullOrEmpty(entidad.Clave))
                throw new Exception("Falta informacion");

            if (this.IConexion.Usuarios!.Any(x => x.Email == entidad.Email))
                throw new Exception("El email ya existe");

            this.IConexion.Usuarios!.Add(entidad!);
            this.IConexion.Auditorias!.Add(
                new Auditorias()
                {
                    Entidad = "Usuarios",
                    Accion = "Insertar",
                    Descripcion = "Se inserto un Usuario",
                    Fecha = DateTime.Now
                });
            this.IConexion.SaveChanges();
            entidad.Clave = null;
            return entidad;
        }

        public Usuarios Login(Usuarios entidad)
        {
            if (string.IsNullOrEmpty(entidad.Email) || string.IsNullOrEmpty(entidad.Clave))
                return new Usuarios();

            var usuario = this.IConexion.Usuarios!
                .Include(x => x._Rol)
                .FirstOrDefault(x => x.Email == entidad.Email &&
                                     x.Clave == entidad.Clave &&
                                     x.Activo);

            if (usuario == null)
                return new Usuarios();

            usuario.Clave = null;
            return usuario;
        }

        private List<Usuarios> SinClaves(List<Usuarios> lista)
        {
            foreach (var usuario in lista)
                usuario.Clave = null;
            return lista;
        }

        private bool Validar(Usuarios entidad)
        {
            return string.IsNullOrEmpty(entidad.Email) ||
                entidad.Rol == 0 ||
                entidad.Persona == 0;
        }
    }
}