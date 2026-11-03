using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class ProveedoresPruebas
    {
        private IConexion conexion;
        private Proveedores? entidad = null;

        public ProveedoresPruebas()
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
            this.entidad = new Proveedores()
            {
                NombreEmpresa = "Insumos Tattoo Co",
                Telefono = "6044445566",
                Direccion = "Calle 10 # 40-20",
                Correo = "contacto@insumostattoo.com",
                Tipo = "Insumos Generales"

            };
            this.conexion.Proveedores!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Proveedores!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.NombreEmpresa = "Insumos Tattoo Global";
            this.entidad!.Telefono = "6044445577";

            var entry = this.conexion!.Entry<Proveedores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Proveedores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

