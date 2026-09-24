using System;
using System.Collections.Generic;
using System.Text;

namespace aplicaciones_libreria.entidades
{
    public class Gastos
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string? Categoria { get; set; }
        public int Sede { get; set; }

        public Sedes? _Sede { get; set; }
    }

}
