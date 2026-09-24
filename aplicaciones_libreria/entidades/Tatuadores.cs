using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Tatuadores
    {
        public int Id { get; set; }
        public string? Licencia { get; set; }
        public int AnExperiencia { get; set; }
        public string? Especialidad { get; set; }
        public int Portafolio { get; set; }
        public int Persona { get; set; }
        public int Sede { get; set; }

        public Portafolios? _Portafolio { get; set; }
        public Personas? _Persona { get; set; }
        public Sedes? _Sede { get; set; }
        public List<Cotizaciones>? Cotizaciones { get; set; }
        public List<Citas>? Citas { get; set; }
    }
}
