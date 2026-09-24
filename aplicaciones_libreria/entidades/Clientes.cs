using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public string? TipoPiel { get; set; }
        public string? Alergias { get; set; }
        public int Persona { get; set; }

        public Personas? _Persona { get; set; }
        public List<Citas>? Citas { get; set; }
    }

}
