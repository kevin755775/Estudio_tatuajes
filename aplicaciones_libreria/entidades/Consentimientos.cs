using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Consentimientos
    {
        public int Id { get; set; }
        public DateTime FechaFirma { get; set; }
        public bool MayorEdad { get; set; }
        public bool FirmaSiNo { get; set; }
        public string? Observaciones { get; set; }

        public List<Citas>? Citas { get; set; }
    }
}
