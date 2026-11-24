using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductosController : ControladorBase
    {
        private IProductosAplicaciones IProductosAplicaciones;

        public ProductosController(IProductosAplicaciones IProductosAplicaciones)
        {
            this.IProductosAplicaciones = IProductosAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Productos>> Consultar()
        {
            try
            {
                return this.IProductosAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Productos> Insertar(Productos entidad)
        {
            try
            {
                return this.IProductosAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Productos> Actualizar(Productos entidad)
        {
            try
            {
                return this.IProductosAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Productos> Borrar(Productos entidad)
        {
            try
            {
                return this.IProductosAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
