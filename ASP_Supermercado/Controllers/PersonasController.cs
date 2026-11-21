using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonasController : ControllerBase
    {
        private IPersonasAplicaciones IPersonasAplicaciones;

        public PersonasController(IPersonasAplicaciones IPersonasAplicaciones)
        {
            this.IPersonasAplicaciones = IPersonasAplicaciones;
        }

        [HttpPost]
        public List<Personas> Consultar()
        {
            return this.IPersonasAplicaciones.Consultar();
        }

        [HttpPost]
        public Personas Insertar(Personas entidad)
        {
            return this.IPersonasAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Personas Actualizar(Personas entidad)
        {
            return this.IPersonasAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Personas Borrar(Personas entidad)
        {
            return this.IPersonasAplicaciones.Borrar(entidad);
        }
    }
}
