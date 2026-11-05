
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface IProveedoresAplicacion
    {
        Proveedores Insertar(Proveedores entidad);
        Proveedores Actualizar(Proveedores entidad);
        List<Proveedores> Consultar();
        List<Proveedores> Buscar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);

    }
}
