using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_EstudioTatuajes.Pages.Ventanas
{
    public class UsuariosModel : PageModel
    {
        private IUsuariosPresentacion IUsuariosPresentacion;
        private IRolesPresentacion IRolesPresentacion;
        private IPersonasPresentacion IPersonasPresentacion;

        public UsuariosModel(IPersonasPresentacion IPersonasPresentacion, IRolesPresentacion IRolesPresentacion, IUsuariosPresentacion IUsuariosPresentacion)
        {
            this.IPersonasPresentacion = IPersonasPresentacion;
            this.IRolesPresentacion = IRolesPresentacion;
            this.IUsuariosPresentacion = IUsuariosPresentacion;

            this.Filtro = new Usuarios();
        }

        [BindProperty] public List<Personas> Personas { get; set; }
        [BindProperty] public List<Roles> Roles { get; set; }

        [BindProperty] public List<Usuarios> Lista { get; set; }
        [BindProperty] public Usuarios? Filtro { get; set; }
        [BindProperty] public Usuarios? Actual { get; set; }
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

                Filtro!.Email = Filtro!.Email ?? "";
                Lista = this.IUsuariosPresentacion.Buscar(Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        private void CargarListas()
        {
            this.Personas = this.IPersonasPresentacion.Consultar();
            this.Roles = this.IRolesPresentacion.Consultar();
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                this.Actual = new Usuarios();
                this.Actual.Activo = true;
                CargarListas();
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
                    this.Actual = this.IUsuariosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IUsuariosPresentacion.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Formulario = true; // Mantiene el formulario abierto si salta error de validación
                try { CargarListas(); } catch { }
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
                CargarListas();
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
                this.Actual = this.IUsuariosPresentacion.Borrar(this.Actual!);
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