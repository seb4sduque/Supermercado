using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacturasController : ControllerBase
    {
        private IFacturasAplicaciones IFacturasAplicaciones;

        public FacturasController(IFacturasAplicaciones IFacturasAplicaciones)
        {
            this.IFacturasAplicaciones = IFacturasAplicaciones;
        }

        [HttpPost]
        public List<Facturas> Consultar()
        {
            return this.IFacturasAplicaciones.Consultar();
        }

        [HttpPost]
        public Facturas Insertar(Facturas entidad)
        {
            return this.IFacturasAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Facturas Actualizar(Facturas entidad)
        {
            return this.IFacturasAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Facturas Borrar(Facturas entidad)
        {
            return this.IFacturasAplicaciones.Borrar(entidad);
        }
    }
}
