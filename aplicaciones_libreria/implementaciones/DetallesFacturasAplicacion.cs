using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;


namespace Aplicaciones_libreria.implementaciones
{
    public class DetallesFacturasAplicacion : IDetallesFacturasAplicacion
    {
        private IConexion IConexion;

        public DetallesFacturasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public DetallesFacturas Actualizar(DetallesFacturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<DetallesFacturas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public DetallesFacturas Borrar(DetallesFacturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.DetallesFacturas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetallesFacturas> Buscar(DetallesFacturas entidad)
        {
            return this.IConexion.DetallesFacturas!
                .Include(x => x._Factura)
                .Include(x => x._Producto)
                .Where(x => x.Factura == entidad.Factura)
                .ToList();
        }

        public List<DetallesFacturas> Consultar()
        {
            return this.IConexion.DetallesFacturas!
                .Include(x => x._Factura)
                .Include(x => x._Producto)
                .Take(5)
                .ToList();
        }

        public DetallesFacturas Insertar(DetallesFacturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.DetallesFacturas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(DetallesFacturas entidad)
        {
            return entidad.Cantidad <= 0 ||
                   entidad.PrecioUnitario <= 0 ||
                   entidad.Subtotal <= 0 ||
                   entidad.Factura == 0 ||
                   entidad.Producto == 0;
        }
    }
}