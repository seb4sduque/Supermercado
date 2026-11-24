using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CargosController : ControladorBase
    {
        private ICargosAplicaciones ICargosAplicaciones;

        public CargosController(ICargosAplicaciones ICargosAplicaciones)
        {
            this.ICargosAplicaciones = ICargosAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Cargos>> Consultar()
        {
            try
            {
                return this.ICargosAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Cargos> Insertar(Cargos entidad)
        {
            try
            {
                return this.ICargosAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Cargos> Actualizar(Cargos entidad)
        {
            try
            {
                return this.ICargosAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Cargos> Borrar(Cargos entidad)
        {
            try
            {
                return this.ICargosAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
