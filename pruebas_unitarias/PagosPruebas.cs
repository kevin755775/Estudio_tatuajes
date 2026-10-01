using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class PagosPruebas
    {
        private IConexion conexion;
        private Pagos? entidad = null;

        public PagosPruebas()
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
            this.entidad = new Pagos()
            {
                MetodoPago = "Efectivo",
                Valor = 150000,
                Fecha = DateTime.Now,
                Referencia = "REF-1001"

            };
            this.conexion.Pagos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Pagos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.MetodoPago = "Transferencia";
            this.entidad!.Valor = 180000;

            var entry = this.conexion!.Entry<Pagos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Pagos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

