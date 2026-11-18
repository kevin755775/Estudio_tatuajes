using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class PortafoliosPresentacion : IPortafoliosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public PortafoliosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Portafolios Actualizar(Portafolios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Portafolios>(
                "Portafolios/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Portafolios Borrar(Portafolios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Portafolios>(
                "Portafolios/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Portafolios> Buscar(Portafolios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Portafolios>>(
                "Portafolios/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Portafolios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Portafolios>>(
                "Portafolios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Portafolios Insertar(Portafolios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Portafolios>(
                "Portafolios/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Portafolios entidad)
        {
            return string.IsNullOrEmpty(entidad.Titulo);
        }
    }
}