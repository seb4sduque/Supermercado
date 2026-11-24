using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoriasController : ControladorBase
    {
        private ICategoriasAplicaciones ICategoriasAplicaciones;

        public CategoriasController(ICategoriasAplicaciones ICategoriasAplicaciones)
        {
            this.ICategoriasAplicaciones = ICategoriasAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Categorias>> Consultar()
        {
            try
            {
                return this.ICategoriasAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Categorias> Insertar(Categorias entidad)
        {
            try
            {
                return this.ICategoriasAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Categorias> Actualizar(Categorias entidad)
        {
            try
            {
                return this.ICategoriasAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Categorias> Borrar(Categorias entidad)
        {
            try
            {
                return this.ICategoriasAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
