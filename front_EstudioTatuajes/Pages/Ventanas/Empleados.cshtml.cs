using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_EstudioTatuajes.Pages.Ventanas
{
    public class EmpleadosModel : PageModel
    {
        private IEmpleadosPresentacion IEmpleadosPresentacion;
        private ISedesPresentacion ISedesPresentacion;
        private IPersonasPresentacion IPersonasPresentacion;

        public EmpleadosModel(IPersonasPresentacion IPersonasPresentacion, ISedesPresentacion ISedesPresentacion, IEmpleadosPresentacion IEmpleadosPresentacion)
        {
            this.IEmpleadosPresentacion = IEmpleadosPresentacion;
            this.ISedesPresentacion = ISedesPresentacion;
            this.IPersonasPresentacion = IPersonasPresentacion;

            this.Filtro = new Empleados();
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Sedes> Sedes { get; set; }
        [BindProperty] public List<Personas> Personas { get; set; }

        [BindProperty] public List<Empleados> Lista { get; set; }
        [BindProperty] public Empleados? Filtro { get; set; }
        [BindProperty] public Empleados? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!.Cargo = Filtro!.Cargo ?? "";
                Lista = this.IEmpleadosPresentacion.Buscar(Filtro!);
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
                this.Actual = new Empleados { FechaIngreso = DateTime.Now };
                this.Sedes = this.ISedesPresentacion.Consultar();
                this.Personas = this.IPersonasPresentacion.Consultar();
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
                    this.Actual = this.IEmpleadosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IEmpleadosPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IEmpleadosPresentacion.Borrar(this.Actual!);
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