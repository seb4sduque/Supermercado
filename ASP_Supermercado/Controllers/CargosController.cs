using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CargosController : ControllerBase
    {
        private ICargosAplicaciones ICargosAplicaciones;

        public CargosController(ICargosAplicaciones ICargosAplicaciones)
        {
            this.ICargosAplicaciones = ICargosAplicaciones;
        }

        [HttpPost]
        public List<Cargos> Consultar()
        {
            return this.ICargosAplicaciones.Consultar();
        }

        [HttpPost]
        public Cargos Insertar(Cargos entidad)
        {
            return this.ICargosAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Cargos Actualizar(Cargos entidad)
        {
            return this.ICargosAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Cargos Borrar(Cargos entidad)
        {
            return this.ICargosAplicaciones.Borrar(entidad);
        }
    }
}
