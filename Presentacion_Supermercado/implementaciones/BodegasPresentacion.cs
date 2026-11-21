using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Presentacion_Supermercado.interfaces;

namespace Presentacion_Supermercado.implementaciones
{
    public class BodegasPresentacion : IBodegasPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public BodegasPresentacion(IComunicaciones Icomunicaciones)
        {
            this.IComunicaciones = Icomunicaciones;
        }

        public Bodegas Insertar(Bodegas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Bodegas>(
                "Bodegas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Bodegas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Bodegas>>(
                "Bodegas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Bodegas Actualizar(Bodegas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Bodegas>(
                "Bodegas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Bodegas Borrar(Bodegas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Bodegas>(
                "Bodegas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}