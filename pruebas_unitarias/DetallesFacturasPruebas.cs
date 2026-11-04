using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.implementaciones;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class DetallesFacturasPruebas
    {
        private IConexion conexion;
        private DetallesFacturas? entidad = null;

        public DetallesFacturasPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            this.entidad = new DetallesFacturas()
            {
                Cantidad = 3,
                PrecioUnitario = 45000,
                Subtotal = 135000,
                Factura = 3,
                Producto = 3,
            };
            this.conexion.DetallesFacturas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DetallesFacturas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Factura = 4;
            this.entidad!.Subtotal = 180000;

            var entry = this.conexion!.Entry<DetallesFacturas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetallesFacturas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

