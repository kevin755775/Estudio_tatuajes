using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Sedes
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Ciudad { get; set; }

        public List<Empleados>? Empleados { get; set; }
        public List<Tatuadores>? Tatuadores { get; set; }
        public List<Gastos>? Gastos { get; set; }
        public List<Citas>? Citas { get; set; }
        public List<ProductosVentas>? ProductosVentas { get; set; }
        public List<Implementos>? Implementos { get; set; }
    }
}
