using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Portafolio")] public Portafolios? _Portafolio { get; set; }
        [ForeignKey("Persona")] public Personas? _Persona { get; set; }
        [ForeignKey("Sede")] public Sedes? _Sede { get; set; }
        public List<Cotizaciones>? Cotizaciones { get; set; }
        public List<Citas>? Citas { get; set; }
    }
}
