using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class PersonasPruebas
    {
        private IConexion conexion;
        private Personas? entidad = null;

        public PersonasPruebas()
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
            this.entidad = new Personas()
            {
                Nombre = "Carlos Mendoza",
                NroDoc = "1020304050",
                Telefono = "3001234567",
                Correo = "carlos@gmail.com",
                FechaNac = new DateTime(1995, 5, 15)

            };
            this.conexion.Personas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Personas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "3009876543";
            this.entidad!.Correo = "carlos.mendoza@gmail.com";

            var entry = this.conexion!.Entry<Personas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Personas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

