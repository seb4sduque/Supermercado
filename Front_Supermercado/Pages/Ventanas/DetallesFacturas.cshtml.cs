using lib_supermercado.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Front_Supermercado.Nucleo;
using Presentacion_Supermercado.interfaces;

namespace Front_Supermercado.Pages.Ventanas
{
    public class DetallesFacturasModel : PageModel
    {
        private IDetallesFacturasPresentacion IDetallesFacturasPresentacion;
        private Catalogos catalogos;

        public DetallesFacturasModel(IDetallesFacturasPresentacion IDetallesFacturasPresentacion,
            Catalogos catalogos)
        {
            this.IDetallesFacturasPresentacion = IDetallesFacturasPresentacion;
            this.catalogos = catalogos;
        }

        // Nombres para mostrar y listas desplegables (el usuario no ve los Id)
        public Dictionary<int, string> NombreFactura { get; set; } = new();
        public List<SelectListItem> OpcionesFactura { get; set; } = new();
        public Dictionary<int, string> NombreProducto { get; set; } = new();
        public List<SelectListItem> OpcionesProducto { get; set; } = new();

        public List<DetallesFacturas>? Lista { get; set; }
        [BindProperty] public DetallesFacturas? Actual { get; set; }
        [BindProperty] public bool Nuevo { get; set; } = false;
        public string? Mensaje { get; set; }
        public bool EsError { get; set; } = false;

        // Permisos por rol: quién puede crear o modificar y quién puede borrar
        public bool PuedeCrear => Permisos.PuedeCrear(HttpContext, "DetallesFacturas");
        public bool PuedeModificar => Permisos.PuedeModificar(HttpContext, "DetallesFacturas");
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
            Mensaje = accion == "borrar" ? Permisos.MensajeBorrar() : Permisos.MensajeEditar("DetallesFacturas", accion);
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

                Lista = this.IDetallesFacturasPresentacion.Consultar();
                CargarListas();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void CargarListas()
        {
            NombreFactura = catalogos.Facturas();
            OpcionesFactura = NombreFactura
                .Select(x => new SelectListItem(x.Value, x.Key.ToString()))
                .OrderBy(x => x.Text).ToList();
            NombreProducto = catalogos.Productos();
            OpcionesProducto = NombreProducto
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
                this.Actual = new DetallesFacturas();
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
                    this.Actual = this.IDetallesFacturasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IDetallesFacturasPresentacion.Actualizar(this.Actual!);

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
                    this.IDetallesFacturasPresentacion.Borrar(entidad);
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
