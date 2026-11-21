using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using presentacion_consola.interfaces;

namespace Aplicaciones_libreria.implementaciones
{
    public class UsuariosPresentacion : IUsuariosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public UsuariosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Usuarios Login(Usuarios entidad)
        {
            if (string.IsNullOrEmpty(entidad.Email) ||
                string.IsNullOrEmpty(entidad.Clave))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Usuarios>(
                "Usuarios/Login",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}