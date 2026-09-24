using aplicaciones_libreria.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace aplicaciones_libreria.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Personas>? Personas { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Portafolios>? Portafolios { get; set; }
        DbSet<Tatuadores>? Tatuadores { get; set; }
        DbSet<Descuentos>? Descuentos { get; set; }
        DbSet<Cotizaciones>? Cotizaciones { get; set; }
        DbSet<Sedes>? Sedes { get; set; }
        DbSet<Gastos>? Gastos { get; set; }
        DbSet<EstilosTatuajes>? EstilosTatuajes { get; set; }
        DbSet<Tatuajes>? Tatuajes { get; set; }
        DbSet<Sesiones>? Sesiones { get; set; }
        DbSet<Consentimientos>? Consentimientos { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<Citas>? Citas { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<ProductosVentas>? ProductosVentas { get; set; }
        DbSet<Implementos>? Implementos { get; set; }
        DbSet<DetallesFacturas>? DetallesFacturas { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}