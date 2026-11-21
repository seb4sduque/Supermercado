using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private IClientesAplicaciones IClientesAplicaciones;

        public ClientesController(IClientesAplicaciones IClientesAplicaciones)
        {
            this.IClientesAplicaciones = IClientesAplicaciones;
        }

        [HttpPost]
        public List<Clientes> Consultar()
        {
            return this.IClientesAplicaciones.Consultar();
        }

        [HttpPost]
        public Clientes Insertar(Clientes entidad)
        {
            return this.IClientesAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Clientes Actualizar(Clientes entidad)
        {
            return this.IClientesAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Clientes Borrar(Clientes entidad)
        {
            return this.IClientesAplicaciones.Borrar(entidad);
        }
    }
}
