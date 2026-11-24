using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControladorBase
    {
        private IClientesAplicaciones IClientesAplicaciones;

        public ClientesController(IClientesAplicaciones IClientesAplicaciones)
        {
            this.IClientesAplicaciones = IClientesAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Clientes>> Consultar()
        {
            try
            {
                return this.IClientesAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Clientes> Insertar(Clientes entidad)
        {
            try
            {
                return this.IClientesAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Clientes> Actualizar(Clientes entidad)
        {
            try
            {
                return this.IClientesAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Clientes> Borrar(Clientes entidad)
        {
            try
            {
                return this.IClientesAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
