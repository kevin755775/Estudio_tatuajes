
using Aplicaciones_libreria.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaciones_libreria.interfaces
{
    public interface IGastosAplicacion
    {
        Gastos Insertar(Gastos entidad);
        Gastos Actualizar(Gastos entidad);
        List<Gastos> Consultar();
        List<Gastos> Buscar(Gastos entidad);
        Gastos Borrar(Gastos entidad);

    }
}
