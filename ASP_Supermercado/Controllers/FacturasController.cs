using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacturasController : ControladorBase
    {
        private IFacturasAplicaciones IFacturasAplicaciones;

        public FacturasController(IFacturasAplicaciones IFacturasAplicaciones)
        {
            this.IFacturasAplicaciones = IFacturasAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Facturas>> Consultar()
        {
            try
            {
                return this.IFacturasAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Facturas> Insertar(Facturas entidad)
        {
            try
            {
                return this.IFacturasAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Facturas> Actualizar(Facturas entidad)
        {
            try
            {
                return this.IFacturasAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Facturas> Borrar(Facturas entidad)
        {
            try
            {
                return this.IFacturasAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
