using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesComprasController : ControladorBase
    {
        private IDetallesComprasAplicaciones IDetallesComprasAplicaciones;

        public DetallesComprasController(IDetallesComprasAplicaciones IDetallesComprasAplicaciones)
        {
            this.IDetallesComprasAplicaciones = IDetallesComprasAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<DetallesCompras>> Consultar()
        {
            try
            {
                return this.IDetallesComprasAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<DetallesCompras> Insertar(DetallesCompras entidad)
        {
            try
            {
                return this.IDetallesComprasAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<DetallesCompras> Actualizar(DetallesCompras entidad)
        {
            try
            {
                return this.IDetallesComprasAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<DetallesCompras> Borrar(DetallesCompras entidad)
        {
            try
            {
                return this.IDetallesComprasAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
