using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProgramacionTurnosController : ControllerBase
    {
        private IProgramacionTurnosAplicaciones IProgramacionTurnosAplicaciones;

        public ProgramacionTurnosController(IProgramacionTurnosAplicaciones IProgramacionTurnosAplicaciones)
        {
            this.IProgramacionTurnosAplicaciones = IProgramacionTurnosAplicaciones;
        }

        [HttpPost]
        public List<ProgramacionTurnos> Consultar()
        {
            return this.IProgramacionTurnosAplicaciones.Consultar();
        }

        [HttpPost]
        public ProgramacionTurnos Insertar(ProgramacionTurnos entidad)
        {
            return this.IProgramacionTurnosAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public ProgramacionTurnos Actualizar(ProgramacionTurnos entidad)
        {
            return this.IProgramacionTurnosAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public ProgramacionTurnos Borrar(ProgramacionTurnos entidad)
        {
            return this.IProgramacionTurnosAplicaciones.Borrar(entidad);
        }
    }
}
