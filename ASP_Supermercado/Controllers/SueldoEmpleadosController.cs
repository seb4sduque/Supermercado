using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SueldoEmpleadosController : ControllerBase
    {
        private ISueldoEmpleadosAplicaciones ISueldoEmpleadosAplicaciones;

        public SueldoEmpleadosController(ISueldoEmpleadosAplicaciones ISueldoEmpleadosAplicaciones)
        {
            this.ISueldoEmpleadosAplicaciones = ISueldoEmpleadosAplicaciones;
        }

        [HttpPost]
        public List<SueldoEmpleados> Consultar()
        {
            return this.ISueldoEmpleadosAplicaciones.Consultar();
        }

        [HttpPost]
        public SueldoEmpleados Insertar(SueldoEmpleados entidad)
        {
            return this.ISueldoEmpleadosAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public SueldoEmpleados Actualizar(SueldoEmpleados entidad)
        {
            return this.ISueldoEmpleadosAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public SueldoEmpleados Borrar(SueldoEmpleados entidad)
        {
            return this.ISueldoEmpleadosAplicaciones.Borrar(entidad);
        }
    }
}
