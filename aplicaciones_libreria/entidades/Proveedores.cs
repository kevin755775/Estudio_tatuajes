using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Proveedores
    {
        public int Id { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Correo { get; set; }
        public string? Tipo { get; set; }

        public List<ProductosVentas>? ProductosVentas { get; set; }
        public List<Implementos>? Implementos { get; set; }
    }
}
