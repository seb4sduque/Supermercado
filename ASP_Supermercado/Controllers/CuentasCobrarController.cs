using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CuentasCobrarController : ControllerBase
    {
        private ICuentasCobrarAplicaciones ICuentasCobrarAplicaciones;

        public CuentasCobrarController(ICuentasCobrarAplicaciones ICuentasCobrarAplicaciones)
        {
            this.ICuentasCobrarAplicaciones = ICuentasCobrarAplicaciones;
        }

        [HttpPost]
        public List<CuentasCobrar> Consultar()
        {
            return this.ICuentasCobrarAplicaciones.Consultar();
        }

        [HttpPost]
        public CuentasCobrar Insertar(CuentasCobrar entidad)
        {
            return this.ICuentasCobrarAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public CuentasCobrar Actualizar(CuentasCobrar entidad)
        {
            return this.ICuentasCobrarAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public CuentasCobrar Borrar(CuentasCobrar entidad)
        {
            return this.ICuentasCobrarAplicaciones.Borrar(entidad);
        }
    }
}
