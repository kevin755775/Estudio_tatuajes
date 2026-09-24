using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Sesiones
    {
        public int Id { get; set; }
        public int NroSesion { get; set; }
        public decimal DuracionHrs { get; set; }
        public DateTime FechaInicio { get; set; }
        public int Tatuaje { get; set; }

        public Tatuajes? _Tatuaje { get; set; }
    }
}
