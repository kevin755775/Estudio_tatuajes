using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicaciones_libreria.implementaciones
{
    public class GastosAplicacion : IGastosAplicacion
    {
        private IConexion IConexion;

        public GastosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Gastos Actualizar(Gastos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Gastos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.Auditorias!.Add(
           new Auditorias()
           {
               Entidad = "Gastos",
               Accion = "Actualizar",   // Actualizar / Borrar
               Descripcion = "Se actualizo un Gasto",
               Fecha = DateTime.Now
           });
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Gastos Borrar(Gastos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Gastos!.Remove(entidad!);
            this.IConexion.Auditorias!.Add(
           new Auditorias()
           {
               Entidad = "Gastos",
               Accion = "Borrar",   // Actualizar / Borrar
               Descripcion = "Se Borro un Gasto",
               Fecha = DateTime.Now
           });
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Gastos> Buscar(Gastos entidad)
        {
            return this.IConexion.Gastos!
                .Include(x => x._Sede)
                .Where(x => x.Descripcion != null && x.Descripcion.Contains(entidad.Descripcion ?? ""))
                .ToList();
        }

        public List<Gastos> Consultar()
        {
            return this.IConexion.Gastos!
                .Include(x => x._Sede)
                
                .ToList();
        }

        public Gastos Insertar(Gastos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Gastos!.Add(entidad!);
            this.IConexion.Auditorias!.Add(
                new Auditorias()
                {
                    Entidad = "Gastos",
                    Accion = "Insertar",   // Actualizar / Borrar
                    Descripcion = "Se inserto un Gasto",
                    Fecha = DateTime.Now
                });
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Gastos entidad)
        {
            return entidad.Valor <= 0 ||
                   string.IsNullOrEmpty(entidad.Descripcion) ||
                   string.IsNullOrEmpty(entidad.Categoria) ||
                   entidad.Sede == 0;
        }
    }
}

