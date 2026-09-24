using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class DetallesFacturas
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public int Factura { get; set; }
        public int Producto { get; set; }

        public Facturas? _Factura { get; set; }
        public ProductosVentas? _Producto { get; set; }
    }

}
