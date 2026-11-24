using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProgramacionTurnosController : ControladorBase
    {
        private IProgramacionTurnosAplicaciones IProgramacionTurnosAplicaciones;

        public ProgramacionTurnosController(IProgramacionTurnosAplicaciones IProgramacionTurnosAplicaciones)
        {
            this.IProgramacionTurnosAplicaciones = IProgramacionTurnosAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<ProgramacionTurnos>> Consultar()
        {
            try
            {
                return this.IProgramacionTurnosAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<ProgramacionTurnos> Insertar(ProgramacionTurnos entidad)
        {
            try
            {
                return this.IProgramacionTurnosAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<ProgramacionTurnos> Actualizar(ProgramacionTurnos entidad)
        {
            try
            {
                return this.IProgramacionTurnosAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<ProgramacionTurnos> Borrar(ProgramacionTurnos entidad)
        {
            try
            {
                return this.IProgramacionTurnosAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
