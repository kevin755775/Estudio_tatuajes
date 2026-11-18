using Aplicaciones_libreria.entidades;
using Aplicaciones_libreria.interfaces;
using Aplicaciones_libreria.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_EstudioTatuajes.Pages.Ventanas
{
    public class ProductosVentasModel : PageModel
    {
        private IProveedoresPresentacion IProveedoresPresentacion;
        private ISedesPresentacion ISedesPresentacion;
        private IProductosVentasPresentacion IProductosVentasPresentacion;

        public ProductosVentasModel(IProveedoresPresentacion IProveedoresPresentacion, ISedesPresentacion ISedesPresentacion, IProductosVentasPresentacion IProductosVentasPresentacion)
        {
            this.ISedesPresentacion = ISedesPresentacion;
            this.IProveedoresPresentacion = IProveedoresPresentacion;
            this.IProductosVentasPresentacion = IProductosVentasPresentacion;
            this.Filtro = new ProductosVentas();
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Proveedores> Proveedores { get; set; }
        [BindProperty] public List<Sedes> Sedes { get; set; }
        [BindProperty] public List<ProductosVentas> Lista { get; set; }
        [BindProperty] public ProductosVentas? Filtro { get; set; }
        [BindProperty] public ProductosVentas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!.Nombre = Filtro!.Nombre ?? "";
                Lista = this.IProductosVentasPresentacion.Buscar(Filtro!);
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
                this.Actual = new ProductosVentas();
                this.Proveedores = this.IProveedoresPresentacion.Consultar();
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
                    this.Actual = this.IProductosVentasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IProductosVentasPresentacion.Actualizar(this.Actual!);
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
                this.Proveedores = this.IProveedoresPresentacion.Consultar();
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
                this.Actual = this.IProductosVentasPresentacion.Borrar(this.Actual!);
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
