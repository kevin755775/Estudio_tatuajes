using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;


namespace Aplicaciones_libreria.implementaciones
{
    public class GastosPresentacion : IGastosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public GastosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Gastos Actualizar(Gastos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Gastos>(
                "Gastos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Gastos Borrar(Gastos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Gastos>(
                "Gastos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Gastos> Buscar(Gastos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Gastos>>(
                "Gastos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Gastos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Gastos>>(
                "Gastos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Gastos Insertar(Gastos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Gastos>(
                "Gastos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Gastos entidad)
        {
            return entidad.Valor <= 0 ||
                   string.IsNullOrEmpty(entidad.Descripcion) ||
                   string.IsNullOrEmpty(entidad.Categoria) ||
                   entidad.Sede == 0;
        }
    }
}