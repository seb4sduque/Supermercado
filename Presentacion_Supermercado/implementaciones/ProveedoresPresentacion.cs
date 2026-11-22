using lib_supermercado.entidades;
using Presentacion_Supermercado.interfaces;

namespace Presentacion_Supermercado.implementaciones
{
    public class ProveedoresPresentacion : IProveedoresPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public ProveedoresPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public Proveedores Insertar(Proveedores entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Proveedores> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<Proveedores>>(
                "Proveedores/Consultar",
                null!);
            task.Wait();
            return task.Result;
        }

        public Proveedores Actualizar(Proveedores entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Proveedores Borrar(Proveedores entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}
