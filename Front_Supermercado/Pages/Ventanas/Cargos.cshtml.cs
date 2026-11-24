using Front_Supermercado.Nucleo;
using lib_supermercado.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Supermercado.interfaces;

namespace Front_Supermercado.Pages.Ventanas
{
    public class CargosModel : PageModel
    {
        private ICargosPresentacion ICargosPresentacion;

        public CargosModel(ICargosPresentacion ICargosPresentacion)
        {
            this.ICargosPresentacion = ICargosPresentacion;
        }

        public List<Cargos>? Lista { get; set; }
        [BindProperty] public Cargos? Actual { get; set; }
        [BindProperty] public bool Nuevo { get; set; } = false;
        public string? Mensaje { get; set; }
        public bool EsError { get; set; } = false;

        // Permisos por rol: quién puede crear o modificar y quién puede borrar
        public bool PuedeCrear => Permisos.PuedeCrear(HttpContext, "Cargos");
        public bool PuedeModificar => Permisos.PuedeModificar(HttpContext, "Cargos");
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
            Mensaje = accion == "borrar" ? Permisos.MensajeBorrar() : Permisos.MensajeEditar("Cargos", accion);
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

                Lista = this.ICargosPresentacion.Consultar();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        public void OnPostBtNuevo()
        {
            if (SinPermiso("crear")) return;
            try
            {
                ModelState.Clear();
                Nuevo = true;
                this.Actual = new Cargos();
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
                    this.Actual = this.ICargosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ICargosPresentacion.Actualizar(this.Actual!);

                ModelState.Clear();
                Nuevo = false;
                this.Actual = null;
                OnPostBtConsultar();
                Mensaje = "Registro guardado.";
            }
            catch (Exception ex)
            {
                Nuevo = true;
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
                    this.ICargosPresentacion.Borrar(entidad);
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
