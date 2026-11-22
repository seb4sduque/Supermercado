using lib_supermercado.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentacion_Supermercado.interfaces;

namespace Front_Supermercado.Pages.Ventanas
{
    public class SueldoEmpleadosModel : PageModel
    {
        private ISueldoEmpleadosPresentacion ISueldoEmpleadosPresentacion;

        public SueldoEmpleadosModel(ISueldoEmpleadosPresentacion ISueldoEmpleadosPresentacion)
        {
            this.ISueldoEmpleadosPresentacion = ISueldoEmpleadosPresentacion;
        }

        public List<SueldoEmpleados>? Lista { get; set; }
        [BindProperty] public SueldoEmpleados? Actual { get; set; }
        [BindProperty] public bool Nuevo { get; set; } = false;
        public string? Mensaje { get; set; }
        public bool EsError { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Lista = this.ISueldoEmpleadosPresentacion.Consultar();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                ModelState.Clear();
                Nuevo = true;
                this.Actual = new SueldoEmpleados();
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
                    this.Actual = this.ISueldoEmpleadosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ISueldoEmpleadosPresentacion.Actualizar(this.Actual!);

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
            try
            {
                OnPostBtConsultar();
                var entidad = Lista?.FirstOrDefault(x => x.Id == id);
                if (entidad != null)
                {
                    this.ISueldoEmpleadosPresentacion.Borrar(entidad);
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
