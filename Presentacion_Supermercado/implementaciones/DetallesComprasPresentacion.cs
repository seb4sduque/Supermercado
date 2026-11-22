using lib_supermercado.entidades;
using Presentacion_Supermercado.interfaces;


namespace Presentacion_Supermercado.implementaciones
{
    public class DetallesComprasPresentacion : IDetallesComprasPresentacion
        
    {
        private IComunicaciones Icomunicaciones;

        public DetallesComprasPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public DetallesCompras Insertar(DetallesCompras entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<DetallesCompras>(
                "DetallesCompras/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesCompras> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<DetallesCompras>>(
                "DetallesCompras/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public DetallesCompras Actualizar(DetallesCompras entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<DetallesCompras>(
                "DetallesCompras/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesCompras Borrar(DetallesCompras entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<DetallesCompras>(
                "DetallesCompras/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}