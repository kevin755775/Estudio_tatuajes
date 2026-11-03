using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class PortafoliosPruebas
    {
        private IConexion conexion;
        private Portafolios? entidad = null;

        public PortafoliosPruebas()
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
            this.entidad = new Portafolios()
            {
                Titulo = "Portafolio Realismo 2026",
                Descripcion = "Colección de diseños de sombras y realismo",
                FechaUltAct = DateTime.Now,
                TotalDisenos = 12

            };
            this.conexion.Portafolios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Portafolios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Titulo = "Portafolio Realismo Actualizado";
            this.entidad!.TotalDisenos = 15;

            var entry = this.conexion!.Entry<Portafolios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Portafolios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

