using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;


namespace Aplicaciones_libreria.implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion IConexion;

        public ClientesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Clientes Actualizar(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Clientes Borrar(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Clientes!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Clientes> Buscar(Clientes entidad)
        {
            return this.IConexion.Clientes!
                .Include(x => x._Persona)
                .Where(x => x.Persona == entidad.Persona)
                .ToList();
        }

        public List<Clientes> Consultar()
        {
            return this.IConexion.Clientes!
                .Include(x => x._Persona)
                .Take(5)
                .ToList();
        }

        public Clientes Insertar(Clientes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Clientes!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Clientes entidad)
        {
            return string.IsNullOrEmpty(entidad.TipoPiel) ||
                   entidad.Persona == 0;
        }
    }
}