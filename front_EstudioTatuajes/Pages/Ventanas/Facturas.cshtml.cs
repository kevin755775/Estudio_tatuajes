using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using front_EstudioTatuajes.Reportes;

namespace front_EstudioTatuajes.Pages.Ventanas
{
    public class FacturasModel : PageModel
    {
        private IFacturasPresentacion IFacturasPresentacion;
        private IPagosPresentacion IPagosPresentacion;
        private IDetallesFacturasPresentacion IDetallesFacturasPresentacion;


        public FacturasModel(IPagosPresentacion IPagosPresentacion, IFacturasPresentacion IFacturasPresentacion, IDetallesFacturasPresentacion IDetallesFacturasPresentacion)
        {
            this.IPagosPresentacion = IPagosPresentacion;
            this.IFacturasPresentacion = IFacturasPresentacion;
            this.IDetallesFacturasPresentacion = IDetallesFacturasPresentacion;

            this.Filtro = new Facturas();
        }
        public IFormFile? FormFile { get; set; }

        [BindProperty] public List<Pagos> Pagos { get; set; }

        [BindProperty] public List<Facturas> Lista { get; set; }
        [BindProperty] public Facturas? Filtro { get; set; }
        [BindProperty] public Facturas? Actual { get; set; }
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

                Lista = this.IFacturasPresentacion.Buscar(Filtro!);
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
                
                this.Actual = new Facturas { Hora = DateTime.Now };
                Formulario = true;
                this.Actual = new Facturas();
                this.Pagos = this.IPagosPresentacion.Consultar();

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
                    this.Actual = this.IFacturasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IFacturasPresentacion.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Formulario = true; // Mantiene el formulario abierto si salta error de validación
                this.Pagos = this.IPagosPresentacion.Consultar();
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
                this.Pagos = this.IPagosPresentacion.Consultar();
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
                this.Actual = this.IFacturasPresentacion.Borrar(this.Actual!);
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
        public IActionResult OnPostBtPdf(string data)
        {
            try
            {
                OnPostBtConsultar();
                var factura = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                var detalles = this.IDetallesFacturasPresentacion.Consultar()
                    .Where(x => x.Factura == factura!.Id)
                    .ToList();

                var pdf = FacturaPdf.Generar(factura!, detalles);
                return File(pdf, "application/pdf", "Factura_" + factura!.Id + ".pdf");
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return Page();
            }
        }
    }
}