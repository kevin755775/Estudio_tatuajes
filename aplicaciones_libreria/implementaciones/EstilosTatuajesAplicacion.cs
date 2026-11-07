using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicaciones_libreria.implementaciones
{
    public class EstilosTatuajesAplicacion : IEstilosTatuajesAplicacion
    {
        private IConexion IConexion;

        public EstilosTatuajesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public EstilosTatuajes Actualizar(EstilosTatuajes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<EstilosTatuajes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public EstilosTatuajes Borrar(EstilosTatuajes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.EstilosTatuajes!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<EstilosTatuajes> Buscar(EstilosTatuajes entidad)
        {
            return this.IConexion.EstilosTatuajes!
                .Where(x => x.Nombre != null && x.Nombre.Contains(entidad.Nombre ?? ""))
                .ToList();
        }

        public List<EstilosTatuajes> Consultar()
        {
            return this.IConexion.EstilosTatuajes!.Take(5).ToList();
        }

        public EstilosTatuajes Insertar(EstilosTatuajes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.EstilosTatuajes!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(EstilosTatuajes entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   string.IsNullOrEmpty(entidad.NivelDificultad);
        }
    }
}

