using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InventariosController : ControladorBase
    {
        private IInventariosAplicaciones IInventariosAplicaciones;

        public InventariosController(IInventariosAplicaciones IInventariosAplicaciones)
        {
            this.IInventariosAplicaciones = IInventariosAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Inventarios>> Consultar()
        {
            try
            {
                return this.IInventariosAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Inventarios> Insertar(Inventarios entidad)
        {
            try
            {
                return this.IInventariosAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Inventarios> Actualizar(Inventarios entidad)
        {
            try
            {
                return this.IInventariosAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Inventarios> Borrar(Inventarios entidad)
        {
            try
            {
                return this.IInventariosAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
