using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovimientosInventariosController : ControladorBase
    {
        private IMovimientosInventariosAplicaciones IMovimientosInventariosAplicaciones;

        public MovimientosInventariosController(IMovimientosInventariosAplicaciones IMovimientosInventariosAplicaciones)
        {
            this.IMovimientosInventariosAplicaciones = IMovimientosInventariosAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<MovimientosInventarios>> Consultar()
        {
            try
            {
                return this.IMovimientosInventariosAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<MovimientosInventarios> Insertar(MovimientosInventarios entidad)
        {
            try
            {
                return this.IMovimientosInventariosAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<MovimientosInventarios> Actualizar(MovimientosInventarios entidad)
        {
            try
            {
                return this.IMovimientosInventariosAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<MovimientosInventarios> Borrar(MovimientosInventarios entidad)
        {
            try
            {
                return this.IMovimientosInventariosAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
