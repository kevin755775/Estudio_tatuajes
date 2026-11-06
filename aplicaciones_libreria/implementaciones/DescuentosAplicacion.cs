using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;


namespace Aplicaciones_libreria.implementaciones
{
    public class DescuentosAplicacion : IDescuentosAplicacion
    {
        private IConexion IConexion;

        public DescuentosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Descuentos Actualizar(Descuentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Descuentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Descuentos Borrar(Descuentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Descuentos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Descuentos> Buscar(Descuentos entidad)
        {
            return this.IConexion.Descuentos!
                .Where(x => x.Codigo == entidad.Codigo)
                .ToList();
        }

        public List<Descuentos> Consultar()
        {
            return this.IConexion.Descuentos!.Take(5).ToList();
        }

        public Descuentos Insertar(Descuentos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Descuentos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Descuentos entidad)
        {
            return entidad.Codigo == 0 ||
                   entidad.PorcentajeDesc <= 0;
        }
    }
}