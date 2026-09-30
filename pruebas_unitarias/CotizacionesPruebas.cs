using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class CotizacionesPruebas
    {
        private IConexion conexion;
        private Cotizaciones? entidad = null;

        public CotizacionesPruebas()
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
            this.entidad = new Cotizaciones()
            {
                ValorEstimado = 180000,
                FechaEmision = DateTime.Now,
                VigenciaDias = 15,
                Tatuador = 3,
                Descuento = 2,
            };
            this.conexion.Cotizaciones!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Cotizaciones!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.VigenciaDias = 30;

            var entry = this.conexion!.Entry<Cotizaciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Cotizaciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

