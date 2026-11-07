using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicaciones_libreria.implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private IConexion IConexion;

        public PagosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Pagos Actualizar(Pagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Pagos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Pagos Borrar(Pagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Pagos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Pagos> Buscar(Pagos entidad)
        {
            return this.IConexion.Pagos!
                .Where(x => x.MetodoPago != null && x.MetodoPago.Contains(entidad.MetodoPago ?? ""))
                .ToList();
        }

        public List<Pagos> Consultar()
        {
            return this.IConexion.Pagos!.Take(5).ToList();
        }

        public Pagos Insertar(Pagos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Pagos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Pagos entidad)
        {
            return string.IsNullOrEmpty(entidad.MetodoPago) ||
                   entidad.Valor <= 0;
        }
    }
}
