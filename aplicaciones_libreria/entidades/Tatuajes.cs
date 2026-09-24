using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Tatuajes
    {
        public int Id { get; set; }
        public string? ZonaCuerpo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
        public bool Color { get; set; }
        public int EstiloTatuaje { get; set; }

        public EstilosTatuajes? _EstiloTatuaje { get; set; }
        public List<Sesiones>? Sesiones { get; set; }
        public List<Citas>? Citas { get; set; }
    }

}
