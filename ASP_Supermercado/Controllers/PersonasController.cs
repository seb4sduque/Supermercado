using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonasController : ControladorBase
    {
        private IPersonasAplicaciones IPersonasAplicaciones;

        public PersonasController(IPersonasAplicaciones IPersonasAplicaciones)
        {
            this.IPersonasAplicaciones = IPersonasAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Personas>> Consultar()
        {
            try
            {
                return this.IPersonasAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Personas> Insertar(Personas entidad)
        {
            try
            {
                return this.IPersonasAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Personas> Actualizar(Personas entidad)
        {
            try
            {
                return this.IPersonasAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Personas> Borrar(Personas entidad)
        {
            try
            {
                return this.IPersonasAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
