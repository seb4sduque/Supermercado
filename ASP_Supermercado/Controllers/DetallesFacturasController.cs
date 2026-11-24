using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesFacturasController : ControladorBase
    {
        private IDetallesFacturasAplicaciones IDetallesFacturasAplicaciones;

        public DetallesFacturasController(IDetallesFacturasAplicaciones IDetallesFacturasAplicaciones)
        {
            this.IDetallesFacturasAplicaciones = IDetallesFacturasAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<DetallesFacturas>> Consultar()
        {
            try
            {
                return this.IDetallesFacturasAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<DetallesFacturas> Insertar(DetallesFacturas entidad)
        {
            try
            {
                return this.IDetallesFacturasAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<DetallesFacturas> Actualizar(DetallesFacturas entidad)
        {
            try
            {
                return this.IDetallesFacturasAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<DetallesFacturas> Borrar(DetallesFacturas entidad)
        {
            try
            {
                return this.IDetallesFacturasAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
