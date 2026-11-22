using lib_supermercado.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Front_Supermercado.Nucleo;
using Presentacion_Supermercado.interfaces;

namespace Front_Supermercado.Pages.Ventanas
{
    public class DetallesComprasModel : PageModel
    {
        private IDetallesComprasPresentacion IDetallesComprasPresentacion;
        private Catalogos catalogos;

        public DetallesComprasModel(IDetallesComprasPresentacion IDetallesComprasPresentacion,
            Catalogos catalogos)
        {
            this.IDetallesComprasPresentacion = IDetallesComprasPresentacion;
            this.catalogos = catalogos;
        }

        // Nombres para mostrar y listas desplegables (el usuario no ve los Id)
        public Dictionary<int, string> NombreProducto { get; set; } = new();
        public List<SelectListItem> OpcionesProducto { get; set; } = new();
        public Dictionary<int, string> NombreCompraProveedor { get; set; } = new();
        public List<SelectListItem> OpcionesCompraProveedor { get; set; } = new();

        public List<DetallesCompras>? Lista { get; set; }
        [BindProperty] public DetallesCompras? Actual { get; set; }
        [BindProperty] public bool Nuevo { get; set; } = false;
        public string? Mensaje { get; set; }
        public bool EsError { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Lista = this.IDetallesComprasPresentacion.Consultar();
                CargarListas();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void CargarListas()
        {
            NombreProducto = catalogos.Productos();
            OpcionesProducto = NombreProducto
                .Select(x => new SelectListItem(x.Value, x.Key.ToString()))
                .OrderBy(x => x.Text).ToList();
            NombreCompraProveedor = catalogos.ComprasProveedores();
            OpcionesCompraProveedor = NombreCompraProveedor
                .Select(x => new SelectListItem(x.Value, x.Key.ToString()))
                .OrderBy(x => x.Text).ToList();
        }

        public void OnPostBtNuevo()
        {
            try
            {
                ModelState.Clear();
                CargarListas();
                Nuevo = true;
                this.Actual = new DetallesCompras();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        public void OnPostBtModificar(int id)
        {
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
            try
            {
                if (this.Actual!.Id == 0)
                    this.Actual = this.IDetallesComprasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IDetallesComprasPresentacion.Actualizar(this.Actual!);

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
            try
            {
                OnPostBtConsultar();
                var entidad = Lista?.FirstOrDefault(x => x.Id == id);
                if (entidad != null)
                {
                    this.IDetallesComprasPresentacion.Borrar(entidad);
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
