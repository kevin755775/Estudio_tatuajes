using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class CotizacionesPresentacion : ICotizacionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public CotizacionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Cotizaciones Actualizar(Cotizaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Cotizaciones>(
                "Cotizaciones/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Cotizaciones Borrar(Cotizaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Cotizaciones>(
                "Cotizaciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Cotizaciones> Buscar(Cotizaciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Cotizaciones>>(
                "Cotizaciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Cotizaciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Cotizaciones>>(
                "Cotizaciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Cotizaciones Insertar(Cotizaciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Cotizaciones>(
                "Cotizaciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Cotizaciones entidad)
        {
            return entidad.ValorEstimado <= 0 ||
                   entidad.VigenciaDias <= 0 ||
                   entidad.Tatuador == 0 ||
                   entidad.Descuento == 0;
        }
    }
}