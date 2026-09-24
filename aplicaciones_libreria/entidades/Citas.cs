using System;
using System.Collections.Generic;
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

        public Tatuajes? _Tatuaje { get; set; }
        public Consentimientos? _Consentimiento { get; set; }
        public Facturas? _Factura { get; set; }
        public Sedes? _Sede { get; set; }
        public Clientes? _Cliente { get; set; }
        public Tatuadores? _Tatuador { get; set; }
    }
}
