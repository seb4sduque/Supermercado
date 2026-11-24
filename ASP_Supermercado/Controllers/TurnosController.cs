using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TurnosController : ControladorBase
    {
        private ITurnosAplicaciones ITurnosAplicaciones;

        public TurnosController(ITurnosAplicaciones ITurnosAplicaciones)
        {
            this.ITurnosAplicaciones = ITurnosAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Turnos>> Consultar()
        {
            try
            {
                return this.ITurnosAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Turnos> Insertar(Turnos entidad)
        {
            try
            {
                return this.ITurnosAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Turnos> Actualizar(Turnos entidad)
        {
            try
            {
                return this.ITurnosAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Turnos> Borrar(Turnos entidad)
        {
            try
            {
                return this.ITurnosAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
