using lib_supermercado.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Front_Supermercado.Nucleo;
using Presentacion_Supermercado.interfaces;

namespace Front_Supermercado.Pages.Ventanas
{
    public class EmpleadosModel : PageModel
    {
        private IEmpleadosPresentacion IEmpleadosPresentacion;
        private Catalogos catalogos;

        public EmpleadosModel(IEmpleadosPresentacion IEmpleadosPresentacion,
            Catalogos catalogos)
        {
            this.IEmpleadosPresentacion = IEmpleadosPresentacion;
            this.catalogos = catalogos;
        }

        // Nombres para mostrar y listas desplegables (el usuario no ve los Id)
        public Dictionary<int, string> NombrePersona { get; set; } = new();
        public List<SelectListItem> OpcionesPersona { get; set; } = new();
        public Dictionary<int, string> NombreCargo { get; set; } = new();
        public List<SelectListItem> OpcionesCargo { get; set; } = new();

        public List<Empleados>? Lista { get; set; }
        [BindProperty] public Empleados? Actual { get; set; }
        [BindProperty] public bool Nuevo { get; set; } = false;
        public string? Mensaje { get; set; }
        public bool EsError { get; set; } = false;

        // Permisos por rol: quién puede crear o modificar y quién puede borrar
        public bool PuedeCrear => Permisos.PuedeCrear(HttpContext, "Empleados");
        public bool PuedeModificar => Permisos.PuedeModificar(HttpContext, "Empleados");
        public bool PuedeBorrar => Permisos.PuedeBorrar(HttpContext);

        private bool SinPermiso(string accion)
        {
            var permitido = accion == "borrar" ? PuedeBorrar
                : accion == "modificar" ? PuedeModificar : PuedeCrear;
            if (permitido) return false;
            Nuevo = false;
            this.Actual = null;
            OnPostBtConsultar();
            EsError = true;
            Mensaje = accion == "borrar" ? Permisos.MensajeBorrar() : Permisos.MensajeEditar("Empleados", accion);
            return true;
        }

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Lista = this.IEmpleadosPresentacion.Consultar();
                CargarListas();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void CargarListas()
        {
            NombrePersona = catalogos.Personas();
            OpcionesPersona = NombrePersona
                .Select(x => new SelectListItem(x.Value, x.Key.ToString()))
                .OrderBy(x => x.Text).ToList();
            NombreCargo = catalogos.Cargos();
            OpcionesCargo = NombreCargo
                .Select(x => new SelectListItem(x.Value, x.Key.ToString()))
                .OrderBy(x => x.Text).ToList();
        }

        public void OnPostBtNuevo()
        {
            if (SinPermiso("crear")) return;
            try
            {
                ModelState.Clear();
                CargarListas();
                Nuevo = true;
                this.Actual = new Empleados();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        public void OnPostBtModificar(int id)
        {
            if (SinPermiso("modificar")) return;
            try
            {
                ModelState.Clear();
                OnPostBtConsultar();
                this.Actual = Lista?.FirstOrDefault(x => x.Id == id);
                Nuevo = this.Actual != null;
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        public void OnPostBtGuardar()
        {
            if (SinPermiso(this.Actual?.Id > 0 ? "modificar" : "crear")) return;
            try
            {
                if (this.Actual!.Id == 0)
                    this.Actual = this.IEmpleadosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IEmpleadosPresentacion.Actualizar(this.Actual!);

                ModelState.Clear();
                Nuevo = false;
                this.Actual = null;
                OnPostBtConsultar();
                Mensaje = "Registro guardado.";
            }
            catch (Exception ex)
            {
                Nuevo = true;
                try { CargarListas(); } catch { }
                Error(ex);
            }
        }

        public void OnPostBtBorrar(int id)
        {
            if (SinPermiso("borrar")) return;
            try
            {
                OnPostBtConsultar();
                var entidad = Lista?.FirstOrDefault(x => x.Id == id);
                if (entidad != null)
                {
                    this.IEmpleadosPresentacion.Borrar(entidad);
                    OnPostBtConsultar();
                    Mensaje = "Registro borrado.";
                }
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        public void OnPostBtCancelar()
        {
            ModelState.Clear();
            Nuevo = false;
            this.Actual = null;
            OnPostBtConsultar();
        }

        private void Error(Exception ex)
        {
            EsError = true;
            Mensaje = ex.GetBaseException().Message;
        }
    }
}
