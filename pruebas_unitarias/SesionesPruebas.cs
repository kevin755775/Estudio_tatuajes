using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class SesionesPruebas
    {
        private IConexion conexion;
        private Sesiones? entidad = null;

        public SesionesPruebas()
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
            this.entidad = new Sesiones()
            {
                NroSesion = 1,
                DuracionHrs = 3.5m,
                FechaInicio = DateTime.Now,
                Tatuaje = 1

            };
            this.conexion.Sesiones!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Sesiones!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.NroSesion = 2;
            this.entidad!.DuracionHrs = 4.0m;

            var entry = this.conexion!.Entry<Sesiones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Sesiones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

