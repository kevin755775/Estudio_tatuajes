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
            this.IConexion.Auditorias!.Add(
           new Auditorias()
           {
               Entidad = "Pagos",
               Accion = "Actualizar",   // Actualizar / Borrar
               Descripcion = "Se actualizo un Pago",
               Fecha = DateTime.Now
           });
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Pagos Borrar(Pagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Pagos!.Remove(entidad!);
            this.IConexion.Auditorias!.Add(
           new Auditorias()
           {
               Entidad = "Pagos",
               Accion = "Borrar",   // Actualizar / Borrar
               Descripcion = "Se Borro un Pago",
               Fecha = DateTime.Now
           });
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Pagos> Buscar(Pagos entidad)
        {
            return this.IConexion.Pagos!
                .Where(x => x.Referencia != null && x.Referencia.Contains(entidad.Referencia ?? ""))
                .ToList();
        }

        public List<Pagos> Consultar()
        {
            return this.IConexion.Pagos!.ToList();
        }

        public Pagos Insertar(Pagos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Pagos!.Add(entidad!);
            this.IConexion.Auditorias!.Add(
                new Auditorias()
                {
                    Entidad = "Pagos",
                    Accion = "Insertar",   // Actualizar / Borrar
                    Descripcion = "Se inserto un Pago",
                    Fecha = DateTime.Now
                });
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Pagos entidad)
        {
            return string.IsNullOrEmpty(entidad.MetodoPago) ||
                string.IsNullOrEmpty(entidad.Referencia) ||
                   entidad.Valor <= 0;
        }
    }
}
