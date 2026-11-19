using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_EstudioTatuajes.Pages.Ventanas
{
    public class PortafoliosModel : PageModel
    {
        private IPortafoliosPresentacion IPortafoliosPresentacion;



        public PortafoliosModel(IPortafoliosPresentacion IPortafoliosPresentacion)
        {

            this.IPortafoliosPresentacion = IPortafoliosPresentacion;


            this.Filtro = new Portafolios();
        }
        public IFormFile? FormFile { get; set; }



        [BindProperty] public List<Portafolios> Lista { get; set; }
        [BindProperty] public Portafolios? Filtro { get; set; }
        [BindProperty] public Portafolios? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!.Titulo = Filtro!.Titulo ?? "";
                Lista = this.IPortafoliosPresentacion.Buscar(Filtro!);
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
                this.Actual = new Portafolios { FechaUltAct = DateTime.Now };
                Formulario = true;
                this.Actual = new Portafolios();


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
                    this.Actual = this.IPortafoliosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IPortafoliosPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IPortafoliosPresentacion.Borrar(this.Actual!);
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