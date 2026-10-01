using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class TatuajesPruebas
    {
        private IConexion conexion;
        private Tatuajes? entidad = null;

        public TatuajesPruebas()
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
            this.entidad = new Tatuajes()
            {
                ZonaCuerpo = "Antebrazo Derecho",
                Ancho = 15.5m,
                Alto = 20.0m,
                Color = true,
                EstiloTatuaje = 1
            };
            this.conexion.Tatuajes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Tatuajes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.ZonaCuerpo = "Brazo Completo";
            this.entidad!.Alto = 25.0m;

            var entry = this.conexion!.Entry<Tatuajes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Tatuajes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

