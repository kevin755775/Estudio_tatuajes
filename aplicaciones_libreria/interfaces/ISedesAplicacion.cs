
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface ISedesAplicacion
    {
        Sedes Insertar(Sedes entidad);
        Sedes Actualizar(Sedes entidad);
        List<Sedes> Consultar();
        List<Sedes> Buscar(Sedes entidad);
        Sedes Borrar(Sedes entidad);

    }
}
