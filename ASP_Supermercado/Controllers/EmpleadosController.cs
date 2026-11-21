using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpleadosController : ControllerBase
    {
        private IEmpleadosAplicaciones IEmpleadosAplicaciones;

        public EmpleadosController(IEmpleadosAplicaciones IEmpleadosAplicaciones)
        {
            this.IEmpleadosAplicaciones = IEmpleadosAplicaciones;
        }

        [HttpPost]
        public List<Empleados> Consultar()
        {
            return this.IEmpleadosAplicaciones.Consultar();
        }

        [HttpPost]
        public Empleados Insertar(Empleados entidad)
        {
            return this.IEmpleadosAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Empleados Actualizar(Empleados entidad)
        {
            return this.IEmpleadosAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Empleados Borrar(Empleados entidad)
        {
            return this.IEmpleadosAplicaciones.Borrar(entidad);
        }
    }
}
