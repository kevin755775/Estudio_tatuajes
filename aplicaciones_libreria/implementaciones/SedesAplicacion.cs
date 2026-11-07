using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicaciones_libreria.implementaciones
{
    public class SedesAplicacion : ISedesAplicacion
    {
        private IConexion IConexion;

        public SedesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Sedes Actualizar(Sedes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Sedes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Sedes Borrar(Sedes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Sedes!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Sedes> Buscar(Sedes entidad)
        {
            return this.IConexion.Sedes!
                .Where(x => x.Nombre != null && x.Nombre.Contains(entidad.Nombre ?? ""))
                .ToList();
        }

        public List<Sedes> Consultar()
        {
            return this.IConexion.Sedes!.Take(5).ToList();
        }

        public Sedes Insertar(Sedes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Sedes!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Sedes entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   string.IsNullOrEmpty(entidad.Ciudad);
        }
    }
}