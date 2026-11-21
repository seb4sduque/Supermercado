using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Supermercado.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BodegasController : ControllerBase
    {
        private IBodegasAplicaciones IBodegasAplicaciones;

        public BodegasController(IBodegasAplicaciones IBodegasAplicaciones)
        {
            this.IBodegasAplicaciones = IBodegasAplicaciones;
        }

        [HttpPost]
        public List<Bodegas> Consultar()
        {
            return this.IBodegasAplicaciones.Consultar();
        }

        [HttpPost]
        public Bodegas Insertar(Bodegas entidad)
        {
            return this.IBodegasAplicaciones.Insertar(entidad);
        }

        [HttpPost]
        public Bodegas Actualizar(Bodegas entidad)
        {
            return this.IBodegasAplicaciones.Actualizar(entidad);
        }

        [HttpPost]
        public Bodegas Borrar(Bodegas entidad)
        {
            return this.IBodegasAplicaciones.Borrar(entidad);
        }
    }
}
