using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class GastosPruebas
    {
        private IConexion conexion;
        private Gastos? entidad = null;

        public GastosPruebas()
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
            this.entidad = new Gastos()
            {
                Valor = 2300000,
                Descripcion = "Mantenimiento Preventivo Sede",
                Fecha = DateTime.Now,
                Categoria = "Mantenimiento",
                Sede = 1,
            };
            this.conexion.Gastos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Gastos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Valor = 5000000;

            var entry = this.conexion!.Entry<Gastos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Gastos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

