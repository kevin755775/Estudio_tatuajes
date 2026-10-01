using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class ProductosVentasPruebas
    {
        private IConexion conexion;
        private ProductosVentas? entidad = null;

        public ProductosVentasPruebas()
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
            this.entidad = new ProductosVentas()
            {
                Nombre = "Crema Post Tatuaje 50ml",
                Precio = 25000,
                Stock = 30,
                Marca = "Balm Tattoo",
                Proveedores = 1, 
                Sede = 1

            };
            this.conexion.ProductosVentas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.ProductosVentas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Crema Post Tatuaje 100ml";
            this.entidad!.Precio = 40000;

            var entry = this.conexion!.Entry<ProductosVentas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.ProductosVentas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

