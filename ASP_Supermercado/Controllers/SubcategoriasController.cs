using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SubcategoriasController : ControllerBase
    {
        private ISubcategoriasAplicaciones ISubcategoriasAplicaciones;

        public SubcategoriasController(ISubcategoriasAplicaciones ISubcategoriasAplicaciones)
        {
            this.ISubcategoriasAplicaciones = ISubcategoriasAplicaciones;
        }

        [HttpPost]
        public List<Subcategorias> Consultar()
        {
            return this.ISubcategoriasAplicaciones.Consultar();
        }

        [HttpPost]
        public Subcategorias Insertar(Subcategorias entidad)
        {
            return this.ISubcategoriasAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Subcategorias Actualizar(Subcategorias entidad)
        {
            return this.ISubcategoriasAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Subcategorias Borrar(Subcategorias entidad)
        {
            return this.ISubcategoriasAplicaciones.Borrar(entidad);
        }
    }
}
