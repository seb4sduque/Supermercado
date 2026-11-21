using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedoresController : ControllerBase
    {
        private IProveedoresAplicaciones IProveedoresAplicaciones;

        public ProveedoresController(IProveedoresAplicaciones IProveedoresAplicaciones)
        {
            this.IProveedoresAplicaciones = IProveedoresAplicaciones;
        }

        [HttpPost]
        public List<Proveedores> Consultar()
        {
            return this.IProveedoresAplicaciones.Consultar();
        }

        [HttpPost]
        public Proveedores Insertar(Proveedores entidad)
        {
            return this.IProveedoresAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Proveedores Actualizar(Proveedores entidad)
        {
            return this.IProveedoresAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Proveedores Borrar(Proveedores entidad)
        {
            return this.IProveedoresAplicaciones.Borrar(entidad);
        }
    }
}
