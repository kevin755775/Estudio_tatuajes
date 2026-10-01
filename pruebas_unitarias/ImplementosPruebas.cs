using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class ImplementosPruebas
    {
        private IConexion conexion;
        private Implementos? entidad = null;

        public ImplementosPruebas()
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
            this.entidad = new Implementos()
            {
                Nombre = "Cinta Grip Tape 5cm",
                Precio = 12000,
                Stock = 50,
                Marca = "Precision",
                Proveedores = 1, 
                Sede = 1

            };
            this.conexion.Implementos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Implementos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Cinta Grip Tape 5cm Modificada";
            this.entidad!.Stock = 45;

            var entry = this.conexion!.Entry<Implementos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Implementos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

