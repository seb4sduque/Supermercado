using lib_supermercado.entidades;
using Presentacion_Supermercado.interfaces;

namespace Presentacion_Supermercado.implementaciones
{
    public class CargosPresentacion : ICargosPresentacion
    {
        private IComunicaciones IComunicaciones; 

        public CargosPresentacion(IComunicaciones Icomunicacion)
        {
            this.IComunicaciones = Icomunicacion;
        }

        public Cargos Insertar(Cargos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Cargos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Cargos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Cargos>>(
                "Cargos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Cargos Actualizar(Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Cargos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Cargos Borrar(Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Cargos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}