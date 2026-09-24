using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public string? Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Sede { get; set; }
        public int Persona { get; set; }

        public Sedes? _Sede { get; set; }
        public Personas? _Persona { get; set; }
    }
}
