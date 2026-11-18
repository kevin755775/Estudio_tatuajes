using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_EstudioTatuajes.Pages.Ventanas
{
    public class CotizacionesModel : PageModel
    {
        private ICotizacionesPresentacion ICotizacionesPresentacion;
        private ITatuadoresPresentacion ITatuadoresPresentacion;
        private IDescuentosPresentacion IDescuentosPresentacion;


        public CotizacionesModel(IDescuentosPresentacion IDescuentosPresentacion, ITatuadoresPresentacion ITatuadoresPresentacion, ICotizacionesPresentacion ICotizacionesPresentacion)
        {
           
            this.ICotizacionesPresentacion = ICotizacionesPresentacion;
            this.IDescuentosPresentacion = IDescuentosPresentacion;
            this.ITatuadoresPresentacion = ITatuadoresPresentacion;


            this.Filtro = new Cotizaciones();
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Descuentos> Descuentos { get; set; }
        [BindProperty] public List<Tatuadores> Tatuadores { get; set; }

        [BindProperty] public List<Cotizaciones> Lista { get; set; }
        [BindProperty] public Cotizaciones? Filtro { get; set; }
        [BindProperty] public Cotizaciones? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                
                Lista = this.ICotizacionesPresentacion.Buscar(Filtro!);
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
                this.Actual = new Cotizaciones();
                this.Tatuadores = this.ITatuadoresPresentacion.Consultar();
                this.Descuentos = this.IDescuentosPresentacion.Consultar();

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
                if (this.Actual!.Id == 0)
                    this.Actual = this.ICotizacionesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ICotizacionesPresentacion.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Formulario = true; // Mantiene el formulario abierto si salta error de validación
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
                if (this.Actual!.Id == 0)
                    return;
                this.Actual = this.ICotizacionesPresentacion.Borrar(this.Actual!);
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