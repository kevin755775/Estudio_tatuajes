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
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public ProductosVentas Borrar(ProductosVentas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.ProductosVentas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ProductosVentas> Buscar(ProductosVentas entidad)
        {
            return this.IConexion.ProductosVentas!
                .Include(x => x._Proveedores)
                .Include(x => x._Sede)
                .Where(x => x.Sede == entidad.Sede)
                .ToList();
        }

        public List<ProductosVentas> Consultar()
        {
            return this.IConexion.ProductosVentas!
                .Include(x => x._Proveedores)
                .Include(x => x._Sede)
                .Take(5)
                .ToList();
        }

        public ProductosVentas Insertar(ProductosVentas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.ProductosVentas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(ProductosVentas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   entidad.Precio <= 0 ||
                   entidad.Proveedores == 0 ||
                   entidad.Sede == 0;
        }
    }
}