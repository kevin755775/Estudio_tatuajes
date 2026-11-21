using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;

namespace Aplicaciones_libreria.implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion IConexion;

        public UsuariosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Usuarios Login(Usuarios entidad)
        {
            if (string.IsNullOrEmpty(entidad.Email) || string.IsNullOrEmpty(entidad.Clave))
                return new Usuarios();

            var usuario = this.IConexion.Usuarios!
                .FirstOrDefault(x => x.Email == entidad.Email &&
                                     x.Clave == entidad.Clave &&
                                     x.Activo);

            if (usuario == null)
                return new Usuarios();

            usuario.Clave = null;
            return usuario;
        }
    }
}