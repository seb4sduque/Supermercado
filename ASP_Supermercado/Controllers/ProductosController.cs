using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductosController : ControllerBase
    {
        private IProductosAplicaciones IProductosAplicaciones;

        public ProductosController(IProductosAplicaciones IProductosAplicaciones)
        {
            this.IProductosAplicaciones = IProductosAplicaciones;
        }

        [HttpPost]
        public List<Productos> Consultar()
        {
            return this.IProductosAplicaciones.Consultar();
        }

        [HttpPost]
        public Productos Insertar(Productos entidad)
        {
            return this.IProductosAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Productos Actualizar(Productos entidad)
        {
            return this.IProductosAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Productos Borrar(Productos entidad)
        {
            return this.IProductosAplicaciones.Borrar(entidad);
        }
    }
}
