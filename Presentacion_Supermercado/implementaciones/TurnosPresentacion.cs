using lib_supermercado.entidades;
using Presentacion_Supermercado.interfaces;


namespace Presentacion_Supermercado.implementaciones
{
    public class TurnosPresentacion : ITurnosPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public TurnosPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public Turnos Insertar(Turnos entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Turnos>(
                 "Turnos/Insertar",
                 entidad);
            task.Wait();
            return task.Result;
        }

        public List<Turnos> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<Turnos>>(
                "Turnos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Turnos Actualizar(Turnos entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Turnos>(
                "Turnos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Turnos Borrar(Turnos entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Turnos>(
                  "Turnos/Borrar",
                  entidad);
            task.Wait();
            return task.Result;
        }
    }
}