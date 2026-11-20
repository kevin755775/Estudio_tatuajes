namespace Aplicaciones_libreria.entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public string? Entidad { get; set; }    
        public string? Accion { get; set; }       
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}