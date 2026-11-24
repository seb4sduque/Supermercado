using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SubcategoriasController : ControladorBase
    {
        private ISubcategoriasAplicaciones ISubcategoriasAplicaciones;

        public SubcategoriasController(ISubcategoriasAplicaciones ISubcategoriasAplicaciones)
        {
            this.ISubcategoriasAplicaciones = ISubcategoriasAplicaciones;
        }

        [HttpPost]
        public ActionResult<List<Subcategorias>> Consultar()
        {
            try
            {
                return this.ISubcategoriasAplicaciones.Consultar();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Subcategorias> Insertar(Subcategorias entidad)
        {
            try
            {
                return this.ISubcategoriasAplicaciones.Insertar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Subcategorias> Actualizar(Subcategorias entidad)
        {
            try
            {
                return this.ISubcategoriasAplicaciones.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpPost]
        public ActionResult<Subcategorias> Borrar(Subcategorias entidad)
        {
            try
            {
                return this.ISubcategoriasAplicaciones.Borrar(entidad);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
