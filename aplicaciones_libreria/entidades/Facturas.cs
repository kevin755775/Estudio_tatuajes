using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public decimal Total { get; set; }
        public decimal IVA { get; set; }
        public int Pago { get; set; }

        public Pagos? _Pago { get; set; }
        public List<Citas>? Citas { get; set; }
        public List<DetallesFacturas>? DetallesFacturas { get; set; }
    }

}
