using lib_supermercado.entidades;
using Presentacion_Supermercado.interfaces;


namespace Presentacion_Supermercado.implementaciones
{
    public class DetallesFacturasPresentacion : IDetallesFacturasPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public DetallesFacturasPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public DetallesFacturas Insertar(DetallesFacturas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<DetallesFacturas>(
                "DetallesFacturas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesFacturas> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<DetallesFacturas>>(
                "DetallesFacturas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public DetallesFacturas Actualizar(DetallesFacturas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<DetallesFacturas>(
                "DetallesFacturas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesFacturas Borrar(DetallesFacturas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<DetallesFacturas>(
                "DetallesFacturas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}