using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aplicaciones_libreria.entidades
{
    public class Gastos
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string? Categoria { get; set; }
        public int Sede { get; set; }

        [ForeignKey("Sede")] public Sedes? _Sede { get; set; }
    }

}
