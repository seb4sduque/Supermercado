using lib_supermercado.entidades;
using Presentacion_Supermercado.interfaces;


namespace Presentacion_Supermercado.implementaciones
{
    public class SueldoEmpleadosPresentacion : ISueldoEmpleadosPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public SueldoEmpleadosPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public SueldoEmpleados Insertar(SueldoEmpleados entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<SueldoEmpleados>(
                 "SueldoEmpleados/Insertar",
                 entidad);
            task.Wait();
            return task.Result;
        }

        public List<SueldoEmpleados> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<SueldoEmpleados>>(
                "SueldoEmpleados/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public SueldoEmpleados Actualizar(SueldoEmpleados entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<SueldoEmpleados>(
                "SueldoEmpleados/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public SueldoEmpleados Borrar(SueldoEmpleados entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<SueldoEmpleados>(
                "SueldoEmpleados/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}