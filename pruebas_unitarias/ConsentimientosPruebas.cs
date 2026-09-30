using aplicaciones_libreria.entidades;
using aplicaciones_libreria.implementaciones;
using aplicaciones_libreria.interfaces;
using aplicaciones_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_consola
{
    [TestClass]
    public class ConsentimientosPruebas
    {
        private IConexion conexion;
        private Consentimientos? entidad = null;

        public ConsentimientosPruebas()
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
            this.entidad = new Consentimientos()
            {
                FechaFirma = DateTime.Now,
                MayorEdad = true,
                FirmaSiNo = true,
                Observaciones = "Ninguna",
            };
            this.conexion.Consentimientos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Consentimientos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Observaciones = "Alergia leve al látex";

            var entry = this.conexion!.Entry<Consentimientos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Consentimientos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

