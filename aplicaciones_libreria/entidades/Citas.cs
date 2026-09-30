using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Citas
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string? Estado { get; set; }
        public int Tatuaje { get; set; }
        public int Consentimiento { get; set; }
        public int Factura { get; set; }
        public int Sede { get; set; }
        public int Cliente { get; set; }
        public int Tatuador { get; set; }
        [ForeignKey("Tatuaje")] public Tatuajes? _Tatuaje { get; set; }
        [ForeignKey("Consentimiento")] public Consentimientos? _Consentimiento { get; set; }
        [ForeignKey("Factura")]   public Facturas? _Factura { get; set; }
        [ForeignKey("Sede")]public Sedes? _Sede { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Tatuador")] public Tatuadores? _Tatuador { get; set; }
    }
}
