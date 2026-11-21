using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComprasProveedoresController : ControllerBase
    {
        private IComprasProveedoresAplicaciones IComprasProveedoresAplicaciones;

        public ComprasProveedoresController(IComprasProveedoresAplicaciones IComprasProveedoresAplicaciones)
        {
            this.IComprasProveedoresAplicaciones = IComprasProveedoresAplicaciones;
        }

        [HttpPost]
        public List<ComprasProveedores> Consultar()
        {
            return this.IComprasProveedoresAplicaciones.Consultar();
        }

        [HttpPost]
        public ComprasProveedores Insertar(ComprasProveedores entidad)
        {
            return this.IComprasProveedoresAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public ComprasProveedores Actualizar(ComprasProveedores entidad)
        {
            return this.IComprasProveedoresAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public ComprasProveedores Borrar(ComprasProveedores entidad)
        {
            return this.IComprasProveedoresAplicaciones.Borrar(entidad);
        }
    }
}
