using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicaciones_libreria.implementaciones
{
    public class FacturasAplicacion : IFacturasAplicacion
    {
        private IConexion IConexion;

        public FacturasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Facturas Actualizar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Facturas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Facturas Borrar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Facturas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Facturas> Buscar(Facturas entidad)
        {
            return this.IConexion.Facturas!
                .Include(x => x._Pago)
                .Where(x => x.Pago == entidad.Pago)
                .ToList();
        }

        public List<Facturas> Consultar()
        {
            return this.IConexion.Facturas!
                .Include(x => x._Pago)
                .Take(5)
                .ToList();
        }

        public Facturas Insertar(Facturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Facturas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Facturas entidad)
        {
            return entidad.Total <= 0 ||
                   entidad.Pago == 0;
        }
    }
}
