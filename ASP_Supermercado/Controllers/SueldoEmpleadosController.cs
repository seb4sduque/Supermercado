using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SueldoEmpleadosController : ControladorBase
    {
        private ISueldoEmpleadosAplicaciones ISueldoEmpleadosAplicaciones;

        public SueldoEmpleadosController(ISueldoEmpleadosAplicaciones ISueldoEmpleadosAplicaciones)
        {
            this.ISueldoEmpleadosAplicaciones = ISueldoEmpleadosAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<SueldoEmpleados>> Consultar()
        {
            try
            {
                return this.ISueldoEmpleadosAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<SueldoEmpleados> Insertar(SueldoEmpleados entidad)
        {
            try
            {
                return this.ISueldoEmpleadosAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<SueldoEmpleados> Actualizar(SueldoEmpleados entidad)
        {
            try
            {
                return this.ISueldoEmpleadosAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<SueldoEmpleados> Borrar(SueldoEmpleados entidad)
        {
            try
            {
                return this.ISueldoEmpleadosAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
