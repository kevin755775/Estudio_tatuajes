using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;


namespace Aplicaciones_libreria.implementaciones
{
    public class ConsentimientosAplicacion : IConsentimientosAplicacion
    {
        private IConexion IConexion;

        public ConsentimientosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Consentimientos Actualizar(Consentimientos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Consentimientos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Consentimientos Borrar(Consentimientos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Consentimientos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Consentimientos> Buscar(Consentimientos entidad)
        {
            return this.IConexion.Consentimientos!
                .Where(x => x.Observaciones != null && x.Observaciones.Contains(entidad.Observaciones ?? ""))
                .ToList();
        }

        public List<Consentimientos> Consultar()
        {
            return this.IConexion.Consentimientos!.Take(5).ToList();
        }

        public Consentimientos Insertar(Consentimientos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Consentimientos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Consentimientos entidad)
        {
            return string.IsNullOrEmpty(entidad.Observaciones);
        }
    }
}