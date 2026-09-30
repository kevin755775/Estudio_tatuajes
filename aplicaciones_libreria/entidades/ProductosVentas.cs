using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class ProductosVentas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? Marca { get; set; }
        public int Proveedores { get; set; }
        public int Sede { get; set; }

        [ForeignKey("Proveedores")] public Proveedores? _Proveedores { get; set; }
        [ForeignKey("Sede")] public Sedes? _Sede { get; set; }
        public List<DetallesFacturas>? DetallesFacturas { get; set; }
    }

}
