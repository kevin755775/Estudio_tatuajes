using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class DescuentosPresentacion : IDescuentosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DescuentosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Descuentos Actualizar(Descuentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Descuentos>(
                "Descuentos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Descuentos Borrar(Descuentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Descuentos>(
                "Descuentos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Descuentos> Buscar(Descuentos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Descuentos>>(
                "Descuentos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Descuentos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Descuentos>>(
                "Descuentos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Descuentos Insertar(Descuentos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Descuentos>(
                "Descuentos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Descuentos entidad)
        {
            return entidad.Codigo == 0 ||
                   entidad.PorcentajeDesc <= 0;
        }
    }
}