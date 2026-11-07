using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicaciones_libreria.implementaciones
{
    public class SesionesAplicacion : ISesionesAplicacion
    {
        private IConexion IConexion;

        public SesionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Sesiones Actualizar(Sesiones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Sesiones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Sesiones Borrar(Sesiones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Sesiones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Sesiones> Buscar(Sesiones entidad)
        {
            return this.IConexion.Sesiones!
                .Include(x => x._Tatuaje)
                .Where(x => x.Tatuaje == entidad.Tatuaje)
                .ToList();
        }

        public List<Sesiones> Consultar()
        {
            return this.IConexion.Sesiones!
                .Include(x => x._Tatuaje)
                .Take(5)
                .ToList();
        }

        public Sesiones Insertar(Sesiones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Sesiones!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Sesiones entidad)
        {
            return entidad.NroSesion <= 0 ||
                   entidad.DuracionHrs <= 0 ||
                   entidad.Tatuaje == 0;
        }
    }
}