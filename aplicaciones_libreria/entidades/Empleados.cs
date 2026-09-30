using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Sede")] public Sedes? _Sede { get; set; }
        [ForeignKey("Persona")] public Personas? _Persona { get; set; }
    }
}
