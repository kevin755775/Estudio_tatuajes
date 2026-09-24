using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Descuentos
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public decimal PorcentajeDesc { get; set; }
        public bool Estado { get; set; }

        public List<Cotizaciones>? Cotizaciones { get; set; }
    }
}
