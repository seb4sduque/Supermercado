using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InventariosController : ControllerBase
    {
        private IInventariosAplicaciones IInventariosAplicaciones;

        public InventariosController(IInventariosAplicaciones IInventariosAplicaciones)
        {
            this.IInventariosAplicaciones = IInventariosAplicaciones;
        }

        [HttpPost]
        public List<Inventarios> Consultar()
        {
            return this.IInventariosAplicaciones.Consultar();
        }

        [HttpPost]
        public Inventarios Insertar(Inventarios entidad)
        {
            return this.IInventariosAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Inventarios Actualizar(Inventarios entidad)
        {
            return this.IInventariosAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Inventarios Borrar(Inventarios entidad)
        {
            return this.IInventariosAplicaciones.Borrar(entidad);
        }
    }
}
