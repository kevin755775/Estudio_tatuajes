using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_consola
{
    [TestClass]
    public class CitasPruebas
    {
        private IConexion conexion;
        private Citas? entidad = null;

        public CitasPruebas()
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
            this.entidad = new Citas()
            {
                FechaHora= DateTime.Now,
                Estado = "Completado",
                Tatuaje = 5,
                Consentimiento = 5,
                Factura = 5,
                Sede = 3,
                Cliente = 5,
                Tatuador = 5,
            };
            this.conexion.Citas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Citas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.FechaHora = DateTime.Now;

            var entry = this.conexion!.Entry<Citas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Citas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

