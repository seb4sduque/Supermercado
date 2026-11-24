using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CuentasCobrarController : ControladorBase
    {
        private ICuentasCobrarAplicaciones ICuentasCobrarAplicaciones;

        public CuentasCobrarController(ICuentasCobrarAplicaciones ICuentasCobrarAplicaciones)
        {
            this.ICuentasCobrarAplicaciones = ICuentasCobrarAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<CuentasCobrar>> Consultar()
        {
            try
            {
                return this.ICuentasCobrarAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<CuentasCobrar> Insertar(CuentasCobrar entidad)
        {
            try
            {
                return this.ICuentasCobrarAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<CuentasCobrar> Actualizar(CuentasCobrar entidad)
        {
            try
            {
                return this.ICuentasCobrarAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<CuentasCobrar> Borrar(CuentasCobrar entidad)
        {
            try
            {
                return this.ICuentasCobrarAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
