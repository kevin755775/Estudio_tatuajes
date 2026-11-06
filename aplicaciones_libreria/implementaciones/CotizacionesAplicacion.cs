using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;


namespace Aplicaciones_libreria.implementaciones
{
    public class CotizacionesAplicacion : ICotizacionesAplicacion
    {
        private IConexion IConexion;

        public CotizacionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Cotizaciones Actualizar(Cotizaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Cotizaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Cotizaciones Borrar(Cotizaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Cotizaciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Cotizaciones> Buscar(Cotizaciones entidad)
        {
            return this.IConexion.Cotizaciones!
                .Include(x => x._Tatuador)
                .Include(x => x._Descuento)
                .Where(x => x.Tatuador == entidad.Tatuador)
                .ToList();
        }

        public List<Cotizaciones> Consultar()
        {
            return this.IConexion.Cotizaciones!
                .Include(x => x._Tatuador)
                .Include(x => x._Descuento)
                .Take(5)
                .ToList();
        }

        public Cotizaciones Insertar(Cotizaciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Cotizaciones!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Cotizaciones entidad)
        {
            return entidad.ValorEstimado <= 0 ||
                   entidad.VigenciaDias <= 0 ||
                   entidad.Tatuador == 0 ||
                   entidad.Descuento == 0;
        }
    }
}