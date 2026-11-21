using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesFacturasController : ControllerBase
    {
        private IDetallesFacturasAplicaciones IDetallesFacturasAplicaciones;

        public DetallesFacturasController(IDetallesFacturasAplicaciones IDetallesFacturasAplicaciones)
        {
            this.IDetallesFacturasAplicaciones = IDetallesFacturasAplicaciones;
        }

        [HttpPost]
        public List<DetallesFacturas> Consultar()
        {
            return this.IDetallesFacturasAplicaciones.Consultar();
        }

        [HttpPost]
        public DetallesFacturas Insertar(DetallesFacturas entidad)
        {
            return this.IDetallesFacturasAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public DetallesFacturas Actualizar(DetallesFacturas entidad)
        {
            return this.IDetallesFacturasAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public DetallesFacturas Borrar(DetallesFacturas entidad)
        {
            return this.IDetallesFacturasAplicaciones.Borrar(entidad);
        }
    }
}
