using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{

    public class EstilosTatuajes
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? NivelDificultad { get; set; }

        public List<Tatuajes>? Tatuajes { get; set; }
    }
}
