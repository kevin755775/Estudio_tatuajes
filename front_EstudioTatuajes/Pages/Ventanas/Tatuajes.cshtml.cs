using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_EstudioTatuajes.Pages.Ventanas
{
    public class TatuajesModel : PageModel
    {
        private IEstilosTatuajesPresentacion IEstilosTatuajesPresentacion;
        private ITatuajesPresentacion ITatuajesPresentacion;

        public TatuajesModel(IEstilosTatuajesPresentacion IEstilosTatuajesPresentacion, ITatuajesPresentacion ITatuajesPresentacion)
        {
            this.IEstilosTatuajesPresentacion = IEstilosTatuajesPresentacion;
            this.ITatuajesPresentacion = ITatuajesPresentacion;
            this.Filtro = new Tatuajes();
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<EstilosTatuajes> EstilosTatuajes { get; set; }
        [BindProperty] public List<Tatuajes> Lista { get; set; }
        [BindProperty] public Tatuajes? Filtro { get; set; }
        [BindProperty] public Tatuajes? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!.ZonaCuerpo = Filtro!.ZonaCuerpo ?? "";
                Lista = this.ITatuajesPresentacion.Buscar(Filtro!);
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
                this.Actual = new Tatuajes();
                this.EstilosTatuajes = this.IEstilosTatuajesPresentacion.Consultar();
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
                    this.Actual = this.ITatuajesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ITatuajesPresentacion.Actualizar(this.Actual!);
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
                this.EstilosTatuajes = this.IEstilosTatuajesPresentacion.Consultar();
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
                this.Actual = this.ITatuajesPresentacion.Borrar(this.Actual!);
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
