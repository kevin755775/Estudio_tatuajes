using aplicaciones_libreria.entidades;
using aplicaciones_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_libreria.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Personas>? Personas { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Portafolios>? Portafolios { get; set; }
        public DbSet<Tatuadores>? Tatuadores { get; set; }
        public DbSet<Descuentos>? Descuentos { get; set; }
        public DbSet<Cotizaciones>? Cotizaciones { get; set; }
        public DbSet<Sedes>? Sedes { get; set; }
        public DbSet<Gastos>? Gastos { get; set; }
        public DbSet<EstilosTatuajes>? EstilosTatuajes { get; set; }
        public DbSet<Tatuajes>? Tatuajes { get; set; }
        public DbSet<Sesiones>? Sesiones { get; set; }
        public DbSet<Consentimientos>? Consentimientos { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Citas>? Citas { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<ProductosVentas>? ProductosVentas { get; set; }
        public DbSet<Implementos>? Implementos { get; set; }
        public DbSet<DetallesFacturas>? DetallesFacturas { get; set; }
    }
}