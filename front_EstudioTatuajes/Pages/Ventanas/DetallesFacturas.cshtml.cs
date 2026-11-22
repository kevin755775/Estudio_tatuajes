using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_EstudioTatuajes.Pages.Ventanas
{
    public class DetallesFacturasModel : PageModel
    {
        private IDetallesFacturasPresentacion IDetallesFacturasPresentacion;
        private IFacturasPresentacion IFacturasPresentacion;
        private IProductosVentasPresentacion IProductosVentasPresentacion;

        public DetallesFacturasModel(IProductosVentasPresentacion IProductosVentasPresentacion, IFacturasPresentacion IFacturasPresentacion, IDetallesFacturasPresentacion IDetallesFacturasPresentacion)
        {
            this.IDetallesFacturasPresentacion = IDetallesFacturasPresentacion;
            this.IFacturasPresentacion = IFacturasPresentacion;
            this.IProductosVentasPresentacion = IProductosVentasPresentacion;

            this.Filtro = new DetallesFacturas();
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Facturas> Facturas { get; set; }
        [BindProperty] public List<ProductosVentas> ProductosVentas { get; set; }

        [BindProperty] public List<DetallesFacturas> Lista { get; set; }
        [BindProperty] public DetallesFacturas? Filtro { get; set; }
        [BindProperty] public DetallesFacturas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                if (String.IsNullOrEmpty(HttpContext.Session.GetString("Usuario")))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }
                Lista = this.IDetallesFacturasPresentacion.Buscar(Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                this.Actual = new DetallesFacturas();
                this.Facturas = this.IFacturasPresentacion.Consultar();
                this.ProductosVentas = this.IProductosVentasPresentacion.Consultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                var rol = HttpContext.Session.GetString("Rol");
                if (rol != "Administrador" && rol != "Recepcionista")
                    return;
                if (this.Actual!.Id == 0)
                    this.Actual = this.IDetallesFacturasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IDetallesFacturasPresentacion.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Formulario = true; // Mantiene el formulario abierto si salta error de validación
                this.Facturas = this.IFacturasPresentacion.Consultar();
                this.ProductosVentas = this.IProductosVentasPresentacion.Consultar();
            }
            finally
            {
                OnPostBtConsultar();
            }
        }

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                this.Facturas = this.IFacturasPresentacion.Consultar(); 
                this.ProductosVentas = this.IProductosVentasPresentacion.Consultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (HttpContext.Session.GetString("Rol") != "Administrador")
                    return;
                if (this.Actual!.Id == 0)
                    return;
                this.Actual = this.IDetallesFacturasPresentacion.Borrar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }
    }
}
