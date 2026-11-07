using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicaciones_libreria.implementaciones
{
    public class TatuadoresAplicacion : ITatuadoresAplicacion
    {
        private IConexion IConexion;

        public TatuadoresAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Tatuadores Actualizar(Tatuadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Tatuadores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Tatuadores Borrar(Tatuadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Tatuadores!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Tatuadores> Buscar(Tatuadores entidad)
        {
            return this.IConexion.Tatuadores!
                .Include(x => x._Portafolio)
                .Include(x => x._Persona)
                .Include(x => x._Sede)
                .Where(x => x.Sede == entidad.Sede)
                .ToList();
        }

        public List<Tatuadores> Consultar()
        {
            return this.IConexion.Tatuadores!
                .Include(x => x._Portafolio)
                .Include(x => x._Persona)
                .Include(x => x._Sede)
                .Take(5)
                .ToList();
        }

        public Tatuadores Insertar(Tatuadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Tatuadores!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Tatuadores entidad)
        {
            return string.IsNullOrEmpty(entidad.Licencia) ||
                   entidad.Portafolio == 0 ||
                   entidad.Persona == 0 ||
                   entidad.Sede == 0;
        }
    }
}
