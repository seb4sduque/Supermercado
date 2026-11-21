using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TurnosController : ControllerBase
    {
        private ITurnosAplicaciones ITurnosAplicaciones;

        public TurnosController(ITurnosAplicaciones ITurnosAplicaciones)
        {
            this.ITurnosAplicaciones = ITurnosAplicaciones;
        }

        [HttpPost]
        public List<Turnos> Consultar()
        {
            return this.ITurnosAplicaciones.Consultar();
        }

        [HttpPost]
        public Turnos Insertar(Turnos entidad)
        {
            return this.ITurnosAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Turnos Actualizar(Turnos entidad)
        {
            return this.ITurnosAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Turnos Borrar(Turnos entidad)
        {
            return this.ITurnosAplicaciones.Borrar(entidad);
        }
    }
}
