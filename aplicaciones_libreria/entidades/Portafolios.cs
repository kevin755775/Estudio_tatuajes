using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Portafolios
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaUltAct { get; set; }
        public int TotalDisenos { get; set; }

        public List<Tatuadores>? Tatuadores { get; set; }
    }
}
