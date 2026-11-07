using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicaciones_libreria.implementaciones
{
    public class PortafoliosAplicacion : IPortafoliosAplicacion
    {
        private IConexion IConexion;

        public PortafoliosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Portafolios Actualizar(Portafolios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Portafolios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Portafolios Borrar(Portafolios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Portafolios!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Portafolios> Buscar(Portafolios entidad)
        {
            return this.IConexion.Portafolios!
                .Where(x => x.Titulo != null && x.Titulo.Contains(entidad.Titulo ?? ""))
                .ToList();
        }

        public List<Portafolios> Consultar()
        {
            return this.IConexion.Portafolios!.Take(5).ToList();
        }

        public Portafolios Insertar(Portafolios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Portafolios!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Portafolios entidad)
        {
            return string.IsNullOrEmpty(entidad.Titulo);
        }
    }
}

