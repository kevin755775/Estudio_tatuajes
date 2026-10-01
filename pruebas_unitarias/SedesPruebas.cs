using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class SedesPruebas
    {
        private IConexion conexion;
        private Sedes? entidad = null;

        public SedesPruebas()
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
            this.entidad = new Sedes()
            {
                Nombre = "Sede Poblado",
                Direccion = "Carrera 43A # 1-50",
                Telefono = "6043001122",
                Ciudad = "Medellín"
            };
            this.conexion.Sedes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Sedes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Sede Poblado Central";
            this.entidad!.Telefono = "6043009988";

            var entry = this.conexion!.Entry<Sedes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Sedes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

