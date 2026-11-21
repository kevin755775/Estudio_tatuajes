using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_EstudioTatuajes.Pages.Ventanas
{
    public class TatuadoresModel : PageModel
    {
        private ITatuadoresPresentacion ITatuadoresPresentacion;
        private IPersonasPresentacion IPersonasPresentacion;
        private IPortafoliosPresentacion IPortafoliosPresentacion;
        private ISedesPresentacion ISedesPresentacion;

        public TatuadoresModel(IPersonasPresentacion IPersonasPresentacion, ITatuadoresPresentacion ITatuadoresPresentacion, IPortafoliosPresentacion IPortafoliosPresentacion, ISedesPresentacion ISedesPresentacion)
        {
            this.IPersonasPresentacion = IPersonasPresentacion;
            this.ITatuadoresPresentacion = ITatuadoresPresentacion;
            this.IPortafoliosPresentacion = IPortafoliosPresentacion;
            this.ISedesPresentacion = ISedesPresentacion;

            this.Filtro = new Tatuadores();
        }
        public IFormFile? FormFile { get; set; }

        [BindProperty] public List<Personas> Personas { get; set; }
        [BindProperty] public List<Portafolios> Portafolios { get; set; }
        [BindProperty] public List<Sedes> Sedes { get; set; }

        [BindProperty] public List<Tatuadores> Lista { get; set; }
        [BindProperty] public Tatuadores? Filtro { get; set; }
        [BindProperty] public Tatuadores? Actual { get; set; }
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
                Filtro!.Licencia = Filtro!.Licencia ?? "";
                Lista = this.ITatuadoresPresentacion.Buscar(Filtro!);
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
                this.Actual = new Tatuadores();
                this.Personas = this.IPersonasPresentacion.Consultar();
                this.Portafolios = this.IPortafoliosPresentacion.Consultar();
                this.Sedes = this.ISedesPresentacion.Consultar();

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
                    this.Actual = this.ITatuadoresPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ITatuadoresPresentacion.Actualizar(this.Actual!);
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
                this.Personas = this.IPersonasPresentacion.Consultar();
                this.Portafolios = this.IPortafoliosPresentacion.Consultar();
                this.Sedes = this.ISedesPresentacion.Consultar();
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
                this.Actual = this.ITatuadoresPresentacion.Borrar(this.Actual!);
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
