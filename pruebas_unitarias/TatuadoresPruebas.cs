using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class TatuadoresPruebas
    {
        private IConexion conexion;
        private Tatuadores? entidad = null;

        public TatuadoresPruebas()
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
            this.entidad = new Tatuadores()
            {
                Licencia = "LIC-998877",
                AnExperiencia = 5,
                Especialidad = "Blackwork",
                Portafolio = 1, 
                Persona = 1,    
                Sede = 1
            };
            this.conexion.Tatuadores!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Tatuadores!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Especialidad = "Blackwork & Neotradicional";
            this.entidad!.AnExperiencia = 6;

            var entry = this.conexion!.Entry<Tatuadores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Tatuadores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

