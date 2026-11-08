using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.implementaciones;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class EstilosTatuajesPruebas
    {
        private IConexion conexion;
        private EstilosTatuajes? entidad = null;

        public EstilosTatuajesPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();
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
            this.entidad = new EstilosTatuajes()
            {
                Nombre = "Minimalista",
                Descripcion = "Trazos sencillos y discretos",
                NivelDificultad = "Media",
            };
            this.conexion.EstilosTatuajes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.EstilosTatuajes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.NivelDificultad = "Baja";

            var entry = this.conexion!.Entry<EstilosTatuajes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.EstilosTatuajes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

