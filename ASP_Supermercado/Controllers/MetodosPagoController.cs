using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MetodosPagoController : ControllerBase
    {
        private IMetodosPagoAplicaciones IMetodosPagoAplicaciones;

        public MetodosPagoController(IMetodosPagoAplicaciones IMetodosPagoAplicaciones)
        {
            this.IMetodosPagoAplicaciones = IMetodosPagoAplicaciones;
        }

        [HttpPost]
        public List<MetodosPago> Consultar()
        {
            return this.IMetodosPagoAplicaciones.Consultar();
        }

        [HttpPost]
        public MetodosPago Insertar(MetodosPago entidad)
        {
            return this.IMetodosPagoAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public MetodosPago Actualizar(MetodosPago entidad)
        {
            return this.IMetodosPagoAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public MetodosPago Borrar(MetodosPago entidad)
        {
            return this.IMetodosPagoAplicaciones.Borrar(entidad);
        }
    }
}
