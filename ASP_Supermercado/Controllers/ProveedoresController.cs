using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedoresController : ControladorBase
    {
        private IProveedoresAplicaciones IProveedoresAplicaciones;

        public ProveedoresController(IProveedoresAplicaciones IProveedoresAplicaciones)
        {
            this.IProveedoresAplicaciones = IProveedoresAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Proveedores>> Consultar()
        {
            try
            {
                return this.IProveedoresAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Proveedores> Insertar(Proveedores entidad)
        {
            try
            {
                return this.IProveedoresAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Proveedores> Actualizar(Proveedores entidad)
        {
            try
            {
                return this.IProveedoresAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Proveedores> Borrar(Proveedores entidad)
        {
            try
            {
                return this.IProveedoresAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
