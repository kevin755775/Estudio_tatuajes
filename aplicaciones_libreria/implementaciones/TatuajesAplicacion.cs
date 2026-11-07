using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicaciones_libreria.implementaciones
{
    public class TatuajesAplicacion : ITatuajesAplicacion
    {
        private IConexion IConexion;

        public TatuajesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Tatuajes Actualizar(Tatuajes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Tatuajes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Tatuajes Borrar(Tatuajes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Tatuajes!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Tatuajes> Buscar(Tatuajes entidad)
        {
            return this.IConexion.Tatuajes!
                .Include(x => x._EstiloTatuaje)
                .Where(x => x.EstiloTatuaje == entidad.EstiloTatuaje)
                .ToList();
        }

        public List<Tatuajes> Consultar()
        {
            return this.IConexion.Tatuajes!
                .Include(x => x._EstiloTatuaje)
                .Take(5)
                .ToList();
        }

        public Tatuajes Insertar(Tatuajes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Tatuajes!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Tatuajes entidad)
        {
            return string.IsNullOrEmpty(entidad.ZonaCuerpo) ||
                   entidad.Ancho <= 0 ||
                   entidad.Alto <= 0 ||
                   entidad.EstiloTatuaje == 0;
        }
    }
}