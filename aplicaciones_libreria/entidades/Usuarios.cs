using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aplicaciones_libreria.entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Clave { get; set; }
        public int Rol { get; set; }
        public int Persona { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }
        [ForeignKey("Persona")] public Personas? _Persona { get; set; }
    }
}
