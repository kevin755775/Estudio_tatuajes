using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicaciones_libreria.implementaciones
{
    public class ImplementosAplicacion : IImplementosAplicacion
    {
        private IConexion IConexion;

        public ImplementosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Implementos Actualizar(Implementos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Implementos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Implementos Borrar(Implementos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Implementos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Implementos> Buscar(Implementos entidad)
        {
            return this.IConexion.Implementos!
                .Include(x => x._Proveedores)
                .Include(x => x._Sede)
                .Where(x => x.Sede == entidad.Sede)
                .ToList();
        }

        public List<Implementos> Consultar()
        {
            return this.IConexion.Implementos!
                .Include(x => x._Proveedores)
                .Include(x => x._Sede)
                .Take(5)
                .ToList();
        }

        public Implementos Insertar(Implementos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Implementos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Implementos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   entidad.Precio <= 0 ||
                   entidad.Proveedores == 0 ||
                   entidad.Sede == 0;
        }
    }
}

