using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Personas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? NroDoc { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaNac { get; set; }

        public List<Clientes>? Clientes { get; set; }
        public List<Empleados>? Empleados { get; set; }
        public List<Tatuadores>? Tatuadores { get; set; }
    }

}
