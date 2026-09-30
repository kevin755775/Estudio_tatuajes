using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Cotizaciones
    {
        public int Id { get; set; }
        public decimal ValorEstimado { get; set; }
        public DateTime FechaEmision { get; set; }
        public int VigenciaDias { get; set; }
        public int Tatuador { get; set; }
        public int Descuento { get; set; }

        [ForeignKey("Tatuador")]public Tatuadores? _Tatuador { get; set; }
        [ForeignKey("Descuento")] public Descuentos? _Descuento { get; set; }
    }
}
