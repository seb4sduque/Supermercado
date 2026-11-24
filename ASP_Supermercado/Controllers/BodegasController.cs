using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BodegasController : ControladorBase
    {
        private IBodegasAplicaciones IBodegasAplicaciones;

        public BodegasController(IBodegasAplicaciones IBodegasAplicaciones)
        {
            this.IBodegasAplicaciones = IBodegasAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Bodegas>> Consultar()
        {
            try
            {
                return this.IBodegasAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Bodegas> Insertar(Bodegas entidad)
        {
            try
            {
                return this.IBodegasAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Bodegas> Actualizar(Bodegas entidad)
        {
            try
            {
                return this.IBodegasAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Bodegas> Borrar(Bodegas entidad)
        {
            try
            {
                return this.IBodegasAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
