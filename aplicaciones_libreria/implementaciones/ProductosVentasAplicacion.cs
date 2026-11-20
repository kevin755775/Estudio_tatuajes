using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicaciones_libreria.implementaciones
{
    public class ProductosVentasAplicacion : IProductosVentasAplicacion
    {
        private IConexion IConexion;

        public ProductosVentasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public ProductosVentas Actualizar(ProductosVentas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<ProductosVentas>(entidad);
            entry.State = EntityState.Modified;
            if (entidad.ImagenProductosVentas == null) entry.Property(x => x.ImagenProductosVentas).IsModified = false;
            this.IConexion.Auditorias!.Add(
           new Auditorias()
           {
               Entidad = "ProductosVentas",
               Accion = "Actualizar",   // Actualizar / Borrar
               Descripcion = "Se actualizo un ProductosVenta",
               Fecha = DateTime.Now
           });
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public ProductosVentas Borrar(ProductosVentas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.ProductosVentas!.Remove(entidad!);
            this.IConexion.Auditorias!.Add(
           new Auditorias()
           {
               Entidad = "ProductosVentas",
               Accion = "Borrar",   // Actualizar / Borrar
               Descripcion = "Se Borro un ProductosVenta",
               Fecha = DateTime.Now
           });
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ProductosVentas> Buscar(ProductosVentas entidad)
        {
            return this.IConexion.ProductosVentas!
                .Include(x => x._Proveedores)
                .Include(x => x._Sede)
                .Where(x => x.Nombre != null && x.Nombre.Contains(entidad.Nombre ?? ""))
                .ToList();
        }

        public List<ProductosVentas> Consultar()
        {
            return this.IConexion.ProductosVentas!
                .Include(x => x._Proveedores)
                .Include(x => x._Sede)
                
                .ToList();
        }

        public ProductosVentas Insertar(ProductosVentas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.ProductosVentas!.Add(entidad!);
            this.IConexion.Auditorias!.Add(
                new Auditorias()
                {
                    Entidad = "ProductosVentas",
                    Accion = "Insertar",   // Actualizar / Borrar
                    Descripcion = "Se inserto un ProductosVenta",
                    Fecha = DateTime.Now
                });
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(ProductosVentas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Marca) ||
                   entidad.Precio <= 0 ||
                   entidad.Proveedores == 0 ||
                   entidad.Sede == 0;
        }
    }
}