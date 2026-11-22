using lib_supermercado.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Supermercado.interfaces;

namespace Front_Supermercado.Pages.Ventanas
{
    public class FacturasModel : PageModel
    {
        private IFacturasPresentacion IFacturasPresentacion;
        private IClientesPresentacion IClientesPresentacion;
        private IEmpleadosPresentacion IEmpleadosPresentacion;
        private IPersonasPresentacion IPersonasPresentacion;
        private IMetodosPagoPresentacion IMetodosPagoPresentacion;

        public FacturasModel(IFacturasPresentacion IFacturasPresentacion,
            IClientesPresentacion IClientesPresentacion,
            IEmpleadosPresentacion IEmpleadosPresentacion,
            IPersonasPresentacion IPersonasPresentacion,
            IMetodosPagoPresentacion IMetodosPagoPresentacion)
        {
            this.IFacturasPresentacion = IFacturasPresentacion;
            this.IClientesPresentacion = IClientesPresentacion;
            this.IEmpleadosPresentacion = IEmpleadosPresentacion;
            this.IPersonasPresentacion = IPersonasPresentacion;
            this.IMetodosPagoPresentacion = IMetodosPagoPresentacion;
        }

        // Listas desplegables (valor = Id, texto = nombre) y nombres para la tabla
        public List<SelectListItem> Clientes { get; set; } = new();
        public List<SelectListItem> Empleados { get; set; } = new();
        public List<SelectListItem> MetodosPago { get; set; } = new();
        public Dictionary<int, string> NombreCliente { get; set; } = new();
        public Dictionary<int, string> NombreEmpleado { get; set; } = new();
        public Dictionary<int, string> NombreMetodoPago { get; set; } = new();

        public List<Facturas>? Lista { get; set; }
        [BindProperty] public Facturas? Actual { get; set; }
        [BindProperty] public bool Nuevo { get; set; } = false;
        public string? Mensaje { get; set; }
        public bool EsError { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Lista = this.IFacturasPresentacion.Consultar();
                CargarListas();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        // El cliente y el empleado se muestran con el nombre de su Persona
        private void CargarListas()
        {
            var personas = this.IPersonasPresentacion.Consultar()
                .ToDictionary(x => x.Id, x => x.Nombre);

            NombreCliente = this.IClientesPresentacion.Consultar()
                .ToDictionary(x => x.Id, x => personas.GetValueOrDefault(x.Persona, ""));
            NombreEmpleado = this.IEmpleadosPresentacion.Consultar()
                .ToDictionary(x => x.Id, x => personas.GetValueOrDefault(x.Persona, ""));
            NombreMetodoPago = this.IMetodosPagoPresentacion.Consultar()
                .ToDictionary(x => x.Id, x => x.Nombre);

            Clientes = NombreCliente.Select(x => new SelectListItem(x.Value, x.Key.ToString())).ToList();
            Empleados = NombreEmpleado.Select(x => new SelectListItem(x.Value, x.Key.ToString())).ToList();
            MetodosPago = NombreMetodoPago.Select(x => new SelectListItem(x.Value, x.Key.ToString())).ToList();
        }

        public void OnPostBtNuevo()
        {
            try
            {
                ModelState.Clear();
                CargarListas();
                Nuevo = true;
                this.Actual = new Facturas();
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
                    this.Actual = this.IFacturasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IFacturasPresentacion.Actualizar(this.Actual!);

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
                    this.IFacturasPresentacion.Borrar(entidad);
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
