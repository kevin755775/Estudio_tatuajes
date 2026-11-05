using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;


namespace Aplicaciones_libreria.implementaciones
{
    public class CitasAplicacion : ICitasAplicacion
    {
        private IConexion IConexion;

        public CitasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Citas Actualizar(Citas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Citas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Citas Borrar(Citas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Citas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Citas> Buscar(Citas entidad)
        {
            return this.IConexion.Citas!
                .Include(x => x._Tatuaje)
                .Include(x => x._Consentimiento)
                .Include(x => x._Factura)
                .Include(x => x._Sede)
                .Include(x => x._Cliente)
                .Include(x => x._Tatuador)
                .Where(x => x.Estado != null && x.Estado.Contains(entidad.Estado ?? ""))
                .ToList();
        }

        public List<Citas> Consultar()
        {
            return this.IConexion.Citas!
                .Include(x => x._Tatuaje)
                .Include(x => x._Consentimiento)
                .Include(x => x._Factura)
                .Include(x => x._Sede)
                .Include(x => x._Cliente)
                .Include(x => x._Tatuador)
                .Take(5) 
                .ToList();
        }

        public Citas Insertar(Citas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Citas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Citas entidad)
        {
           
            return string.IsNullOrEmpty(entidad.Estado) ||
                   entidad.Cliente == 0 ||
                   entidad.Tatuador == 0 ||
                   entidad.Sede == 0;
        }
    }
}
