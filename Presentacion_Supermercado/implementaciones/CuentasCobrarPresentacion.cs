using lib_supermercado.entidades;
using Presentacion_Supermercado.interfaces;


namespace Presentacion_Supermercado.implementaciones
{
    public class CuentasCobrarPresentacion : ICuentasCobrarPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public CuentasCobrarPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public CuentasCobrar Insertar(CuentasCobrar entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<CuentasCobrar>(
                "CuentasCobrar/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<CuentasCobrar> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<CuentasCobrar>>(
                "CuentasCobrar/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public CuentasCobrar Actualizar(CuentasCobrar entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<CuentasCobrar>(
                "CuentasCobrar/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public CuentasCobrar Borrar(CuentasCobrar entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<CuentasCobrar>(
                "CuentasCobrar/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}