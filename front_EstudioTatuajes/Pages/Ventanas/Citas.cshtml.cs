using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_EstudioTatuajes.Pages.Ventanas
{
    public class CitasModel : PageModel
    {
        private IClientesPresentacion IClientesPresentacion;
        private ITatuadoresPresentacion ITatuadoresPresentacion;
        private ICitasPresentacion ICitasPresentacion;

        public CitasModel(IClientesPresentacion IClientesPresentacion, ITatuadoresPresentacion ITatuadoresPresentacion, ICitasPresentacion ICitasPresentacion)
        {
            this.IClientesPresentacion = IClientesPresentacion;
            this.ICitasPresentacion = ICitasPresentacion;
            this.ITatuadoresPresentacion = ITatuadoresPresentacion;
            this.Filtro = new Citas();
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Clientes> Clientes { get; set; }
        [BindProperty] public List<Tatuadores> Tatuadores { get; set; }
        [BindProperty] public List<Citas> Lista { get; set; }
        [BindProperty] public Citas? Filtro { get; set; }
        [BindProperty] public Citas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!.Estado = Filtro!.Estado ?? "";
                Lista = this.ICitasPresentacion.Buscar(Filtro!);
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
                this.Actual = new Citas { FechaHora = DateTime.Now };
                this.Tatuadores = this.ITatuadoresPresentacion.Consultar();
                this.Clientes = this.IClientesPresentacion.Consultar();
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
                    this.Actual = this.ICitasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ICitasPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.ICitasPresentacion.Borrar(this.Actual!);
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