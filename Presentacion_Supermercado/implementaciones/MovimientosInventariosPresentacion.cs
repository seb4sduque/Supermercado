using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion_Supermercado.implementaciones
{
    public class MovimientosInventariosPresentacion : IMovimientosInventariosPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public MovimientosInventariosPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public MovimientosInventarios Insertar(MovimientosInventarios entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<MovimientosInventarios>(
                "MovimientosInventarios/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<MovimientosInventarios> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<MovimientosInventarios>>(
                "MovimientosInventarios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public MovimientosInventarios Actualizar(MovimientosInventarios entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<MovimientosInventarios>(
                "MovimientosInventarios/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public MovimientosInventarios Borrar(MovimientosInventarios entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<MovimientosInventarios>(
                "MovimientosInventarios/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}