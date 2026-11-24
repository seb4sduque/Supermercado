using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MetodosPagoController : ControladorBase
    {
        private IMetodosPagoAplicaciones IMetodosPagoAplicaciones;

        public MetodosPagoController(IMetodosPagoAplicaciones IMetodosPagoAplicaciones)
        {
            this.IMetodosPagoAplicaciones = IMetodosPagoAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<MetodosPago>> Consultar()
        {
            try
            {
                return this.IMetodosPagoAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<MetodosPago> Insertar(MetodosPago entidad)
        {
            try
            {
                return this.IMetodosPagoAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<MetodosPago> Actualizar(MetodosPago entidad)
        {
            try
            {
                return this.IMetodosPagoAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<MetodosPago> Borrar(MetodosPago entidad)
        {
            try
            {
                return this.IMetodosPagoAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
