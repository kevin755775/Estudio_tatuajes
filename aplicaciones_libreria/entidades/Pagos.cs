using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Pagos
    {
        public int Id { get; set; }
        public string? MetodoPago { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
        public string? Referencia { get; set; }

        public List<Facturas>? Facturas { get; set; }
    }

}
