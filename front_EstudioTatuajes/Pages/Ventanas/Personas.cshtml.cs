using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_EstudioTatuajes.Pages.Ventanas
{
    public class PersonasModel : PageModel
    {
        private IPersonasPresentacion IPersonasPresentacion;



        public PersonasModel(IPersonasPresentacion IPersonasPresentacion)
        {

            this.IPersonasPresentacion = IPersonasPresentacion;


            this.Filtro = new Personas();
        }
        public IFormFile? FormFile { get; set; }



        [BindProperty] public List<Personas> Lista { get; set; }
        [BindProperty] public Personas? Filtro { get; set; }
        [BindProperty] public Personas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!.Nombre = Filtro!.Nombre ?? "";
                Lista = this.IPersonasPresentacion.Buscar(Filtro!);
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
                this.Actual = new Personas { FechaNac = DateTime.Now };
                Formulario = true;
                this.Actual = new Personas();


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
                if (FormFile != null)
                {
                    if (FormFile.Length > 500 * 1024)
                        throw new Exception("La imagen no puede superar 500 KB");
                    var memoryStream = new MemoryStream();
                    FormFile.CopyToAsync(memoryStream).Wait();
                    Actual!.ImagenPersonas = Convert.ToBase64String(memoryStream.ToArray());
                    memoryStream.Dispose();
                }
                if (this.Actual!.Id == 0)
                    this.Actual = this.IPersonasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IPersonasPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IPersonasPresentacion.Borrar(this.Actual!);
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