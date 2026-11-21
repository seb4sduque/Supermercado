using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesComprasController : ControllerBase
    {
        private IDetallesComprasAplicaciones IDetallesComprasAplicaciones;

        public DetallesComprasController(IDetallesComprasAplicaciones IDetallesComprasAplicaciones)
        {
            this.IDetallesComprasAplicaciones = IDetallesComprasAplicaciones;
        }

        [HttpPost]
        public List<DetallesCompras> Consultar()
        {
            return this.IDetallesComprasAplicaciones.Consultar();
        }

        [HttpPost]
        public DetallesCompras Insertar(DetallesCompras entidad)
        {
            return this.IDetallesComprasAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public DetallesCompras Actualizar(DetallesCompras entidad)
        {
            return this.IDetallesComprasAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public DetallesCompras Borrar(DetallesCompras entidad)
        {
            return this.IDetallesComprasAplicaciones.Borrar(entidad);
        }
    }
}
