using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovimientosInventariosController : ControllerBase
    {
        private IMovimientosInventariosAplicaciones IMovimientosInventariosAplicaciones;

        public MovimientosInventariosController(IMovimientosInventariosAplicaciones IMovimientosInventariosAplicaciones)
        {
            this.IMovimientosInventariosAplicaciones = IMovimientosInventariosAplicaciones;
        }

        [HttpPost]
        public List<MovimientosInventarios> Consultar()
        {
            return this.IMovimientosInventariosAplicaciones.Consultar();
        }

        [HttpPost]
        public MovimientosInventarios Insertar(MovimientosInventarios entidad)
        {
            return this.IMovimientosInventariosAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public MovimientosInventarios Actualizar(MovimientosInventarios entidad)
        {
            return this.IMovimientosInventariosAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public MovimientosInventarios Borrar(MovimientosInventarios entidad)
        {
            return this.IMovimientosInventariosAplicaciones.Borrar(entidad);
        }
    }
}
