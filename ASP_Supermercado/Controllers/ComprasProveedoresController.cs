using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComprasProveedoresController : ControladorBase
    {
        private IComprasProveedoresAplicaciones IComprasProveedoresAplicaciones;

        public ComprasProveedoresController(IComprasProveedoresAplicaciones IComprasProveedoresAplicaciones)
        {
            this.IComprasProveedoresAplicaciones = IComprasProveedoresAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<ComprasProveedores>> Consultar()
        {
            try
            {
                return this.IComprasProveedoresAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<ComprasProveedores> Insertar(ComprasProveedores entidad)
        {
            try
            {
                return this.IComprasProveedoresAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<ComprasProveedores> Actualizar(ComprasProveedores entidad)
        {
            try
            {
                return this.IComprasProveedoresAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<ComprasProveedores> Borrar(ComprasProveedores entidad)
        {
            try
            {
                return this.IComprasProveedoresAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
