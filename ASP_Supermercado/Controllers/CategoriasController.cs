using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoriasController : ControllerBase
    {
        private ICategoriasAplicaciones ICategoriasAplicaciones;

        public CategoriasController(ICategoriasAplicaciones ICategoriasAplicaciones)
        {
            this.ICategoriasAplicaciones = ICategoriasAplicaciones;
        }

        [HttpPost]
        public List<Categorias> Consultar()
        {
            return this.ICategoriasAplicaciones.Consultar();
        }

        [HttpPost]
        public Categorias Insertar(Categorias entidad)
        {
            return this.ICategoriasAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Categorias Actualizar(Categorias entidad)
        {
            return this.ICategoriasAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Categorias Borrar(Categorias entidad)
        {
            return this.ICategoriasAplicaciones.Borrar(entidad);
        }
    }
}
