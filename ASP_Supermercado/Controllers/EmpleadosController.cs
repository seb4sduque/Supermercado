using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpleadosController : ControladorBase
    {
        private IEmpleadosAplicaciones IEmpleadosAplicaciones;

        public EmpleadosController(IEmpleadosAplicaciones IEmpleadosAplicaciones)
        {
            this.IEmpleadosAplicaciones = IEmpleadosAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Empleados>> Consultar()
        {
            try
            {
                return this.IEmpleadosAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Empleados> Insertar(Empleados entidad)
        {
            try
            {
                return this.IEmpleadosAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Empleados> Actualizar(Empleados entidad)
        {
            try
            {
                return this.IEmpleadosAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Empleados> Borrar(Empleados entidad)
        {
            try
            {
                return this.IEmpleadosAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
